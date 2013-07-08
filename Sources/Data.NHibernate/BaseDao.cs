using System.Collections.Generic;
using Common.Data.Core;
using Common.Data.Core.Conditions;
using Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Data.NHibernate
{
    public class BaseDao : NHibernateBase, IBaseDao
    {
        private readonly IConditionResolver<ICriteria> _conditionResolver;

        public BaseDao(string connectionString, IConditionResolver conditionResolver)
            : base(connectionString)
        {
            _conditionResolver = (IConditionResolver<ICriteria>)conditionResolver;
        }

        protected IList<T> SelectAlias<T>(SimpleExpression expression, string associationPath, string alias)
            where T : class, IEntityBase, new()
        {
            return TryExecute(() => Session.CreateCriteria<T>()
                  .CreateAlias(associationPath, alias)
                  .Add(expression)
                  .List<T>());
        }

        public PagedResult<T> SelectRange<T>(SelectCondition condition)
            where T : IEntityBase
        {
            return TryExecute(() =>
                 {
                     var creteria = Session.CreateCriteria(typeof(T));
                     creteria = _conditionResolver.Where(creteria, condition);
                     creteria = _conditionResolver.OrderBy(creteria, condition);
                     return _conditionResolver.ToPagedResult<T>(creteria, condition);
                 });
        }

        public bool IsExist<T>(SelectCondition condition)
        {
            return TryExecute(() =>
            {
                var creteria = Session.CreateCriteria(typeof(T));
                creteria = _conditionResolver.Where(creteria, condition);
                creteria = creteria.SetProjection(Projections.RowCountInt64());
                creteria.ClearOrders();
                var itemscount = (long)creteria.UniqueResult();
                return itemscount > 0;
            });
        }

        public T Select<T>(int id) where T : class, IEntityBase
        {
            return TryExecute(() => (T)Session.CreateCriteria(typeof(T))
                                      .Add(Restrictions.Eq(EntityBase.GetFieldName<T>(e => e.Id), id))
                                      .UniqueResult());
        }

        public virtual T Select<T>(SelectCondition condition)
            where T : class, IEntityBase
        {
            return TryExecute(() =>
                {
                    var creteria = Session.CreateCriteria(typeof(T));
                    creteria = _conditionResolver.Where(creteria, condition);
                    creteria = _conditionResolver.OrderBy(creteria, condition);
                    return creteria.UniqueResult<T>();
                });
        }




        public virtual T SaveOrUpdate<T>(T obj)
            where T : IEntityBase
        {
            return TryExecute(() =>
                                  {
                                      Session.SaveOrUpdate(obj);
                                      Session.Flush();
                                      return obj;
                                  });
        }

        public virtual bool Delete<T>(int id)
            where T : class, IEntityBase
        {
            return TryExecute(() =>
            {
                var project = (T)Session.CreateCriteria(typeof(T))
                                       .Add(Restrictions.Eq(EntityBase.GetFieldName<T>(e => e.Id), id))
                                       .UniqueResult();

                if (project != null)
                {
                    Session.Delete(project);
                    Session.Flush();
                }
                return true;
            });
        }
    }
}
