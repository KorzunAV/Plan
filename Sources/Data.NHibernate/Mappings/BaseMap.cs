using Entities;
using Entities.Entity;
using FluentNHibernate.Mapping;

namespace Data.NHibernate.Mappings
{
	public class BaseMap<T> : ClassMap<T> where T : IEntityBase
	{
		public BaseMap()
		{
			Id(x => x.Id);
			OptimisticLock.Version();
			Version(entity => entity.Version);
		}
	}
}
