using Common.Data.Core;
using Common.Data.Core.Conditions;
using NHibernate;
using NHibernate.Criterion;

namespace Data.NHibernate
{
    public class ConditionResolver : IConditionResolver<ICriteria>
    {
        public ICriteria Where(ICriteria criteria, SelectCondition condition)
        {
            foreach (var rule in condition.Where.Rules)
            {
                switch (rule.Operation)
                {
                    case Rule.Operations.Eq:
                        {
                            criteria.Add(Restrictions.Eq(rule.PropertyName, rule.Value));
                            break;
                        }
                    case Rule.Operations.Like:
                        {
                            criteria.Add(Restrictions.Like(rule.PropertyName, rule.Value));
                            break;
                        }
                }
            }
            return criteria;
        }

        public ICriteria OrderBy(ICriteria criteria, SelectCondition condition)
        {
            foreach (var orderBy in condition.OrdersBy)
            {
                var order = new Order(orderBy.Column, orderBy.Asc);
                criteria.AddOrder(order);
            }
            return criteria;
        }

        public PagedResult<TE> ToPagedResult<TE>(ICriteria criteria, SelectCondition condition) where TE : IEntityBase
        {
            ICriteria countCriteria = CriteriaTransformer.Clone(criteria).SetProjection(Projections.RowCountInt64());
            countCriteria.ClearOrders();
            var itemscount = (long)countCriteria.UniqueResult();

            var items = criteria.SetMaxResults(condition.PageSize)
                .SetFirstResult((condition.PageIndex - 1) * condition.PageSize)
                .List<TE>();
            var result = new PagedResult<TE>(items, itemscount);
            return result;
        }
    }
}
