using Entities.Entity;
using FluentNHibernate.Mapping;

namespace Data.NHibernate.Mappings
{
	public class UserRoleMap : ClassMap<UserRole>
	{
		public UserRoleMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			OptimisticLock.Version();
			Version(entity => entity.Version);
		}
	}
}
