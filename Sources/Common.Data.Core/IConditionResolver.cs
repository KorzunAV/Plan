namespace Common.Data.Core
{
    public interface IConditionResolver
    {
        PagedResult<TE> AddCondition<T, TE>(T criteria, SelectCondition condition) where TE : IEntityBase;
    }
}
