using System.Collections.Generic;

namespace Entities.Entity
{
	public interface IBaseDao
	{
		IList<T> SelectAll<T>() where T : IEntityBase;

		Page<T> SelectRange<T>(int itemPerPage, int currentPage) where T : class, IEntityBase, new();

		T Select<T>(int id) where T : class, IEntityBase;
		
		T SaveOrUpdate<T>(T obj) where T : IEntityBase;

		bool Delete<T>(int id) where T : class, IEntityBase;
	}
}