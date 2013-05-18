using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class SystemUserMap : BaseMap<SystemUser>
	{
		public SystemUserMap()
		{
			Map(x => x.Name);
			Map(x => x.Login);
			Map(x => x.Password);
			References(x => x.UserRole);
		}
	}
}
