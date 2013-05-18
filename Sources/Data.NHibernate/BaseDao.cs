using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Entity;
using NHibernate.Criterion;

namespace Data.NHibernate
{
	public class BaseDao : NHibernateBase, IBaseDao
	{
		public BaseDao(string connectionString)
			: base(connectionString) { }

		protected IList<T> SelectAlias<T>(SimpleExpression expression, string associationPath, string alias)
			where T : class, IEntityBase, new()
		{
			return TryExecute(() => Session.CreateCriteria<T>()
				  .CreateAlias(associationPath, alias)
				  .Add(expression)
				  .List<T>());
		}

		public virtual IList<T> SelectAll<T>()
			where T : IEntityBase
		{

			return TryExecute(() => Session.CreateCriteria(typeof(T))
							 .List<T>());
		}

		public virtual Page<T> SelectRange<T>(int itemPerPage, int currentPage)
			where T : class, IEntityBase, new()
		{
			return TryExecute(() =>
								  {
									  var page = new Page<T>(itemPerPage, currentPage);

									  //TODO: CR: KOA-FIX: Usage of 'as' is incorrect
									  var t = Session.CreateCriteria(typeof(T))
										  .List<T>();
									  page.MaxIndex = t.Count() - 1;
									  page.Items = t.Skip(page.StartIndex - 1).Take(itemPerPage);
									  return page;
								  });
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
