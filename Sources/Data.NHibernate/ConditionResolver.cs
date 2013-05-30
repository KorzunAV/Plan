using Common.Data.Core;
using NHibernate;
using NHibernate.Criterion;

namespace Data.NHibernate
{
    public class ConditionResolver : IConditionResolver
    {
        public PagedResult<TE> AddCondition<T, TE>(T criteria, SelectCondition condition) where TE : IEntityBase
        {
            var typedCriteria = (ICriteria)criteria;

            foreach (var orderBy in condition.OrdersBy)
            {
                var order = new Order(orderBy.Column, orderBy.Asc);
                typedCriteria.AddOrder(order);
            }

            foreach (var rule in condition.Where.Rules)
            {
                //typedCriteria.CreateCriteria()
            }

            ICriteria countCriteria = CriteriaTransformer.Clone(typedCriteria).SetProjection(Projections.RowCountInt64());
            countCriteria.ClearOrders();
            var itemscount = (long)countCriteria.UniqueResult();

            var items = typedCriteria.SetMaxResults(condition.PageSize).SetFirstResult(condition.PageIndex).List<TE>();
            var result = new PagedResult<TE>(items, itemscount);
            return result;
        }
    }
}
