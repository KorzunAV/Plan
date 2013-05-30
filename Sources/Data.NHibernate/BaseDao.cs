using System.Collections.Generic;
using Common.Data.Core;
using Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Data.NHibernate
{
    public class BaseDao : NHibernateBase, IBaseDao
    {
        private readonly IConditionResolver _conditionResolver;

        public BaseDao(string connectionString, IConditionResolver conditionResolver)
            : base(connectionString)
        {
            _conditionResolver = conditionResolver;
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
            return TryExecute(() => _conditionResolver.AddCondition<ICriteria, T>(Session.CreateCriteria(typeof(T)), condition));
        }

        public virtual T Select<T>(int id)
            where T : class, IEntityBase
        {
            return TryExecute(() => (T)Session.CreateCriteria(typeof(T))
                                       .Add(Restrictions.Eq(EntityBase.GetFieldName<T>(e => e.Id), id))
                                       .UniqueResult());
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
