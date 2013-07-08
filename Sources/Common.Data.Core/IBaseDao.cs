using Common.Data.Core.Conditions;

namespace Common.Data.Core
{
	public interface IBaseDao
	{
        PagedResult<T> SelectRange<T>(SelectCondition condition) where T : IEntityBase;

        bool IsExist<T>(SelectCondition condition);
        
		T Select<T>(int id) where T : class, IEntityBase;
		
		T SaveOrUpdate<T>(T obj) where T : IEntityBase;

		bool Delete<T>(int id) where T : class, IEntityBase;
	}
}