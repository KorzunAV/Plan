namespace Common.Data.Core.Conditions
{
    public interface IConditionResolver<T> : IConditionResolver
    {
        T Where(T criteria, SelectCondition condition);
        T OrderBy(T criteria, SelectCondition condition);
        PagedResult<TE> ToPagedResult<TE>(T criteria, SelectCondition condition) where TE : IEntityBase;
    }

    public interface IConditionResolver
    {
    }
}
