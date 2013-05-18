using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class TagMap : BaseMap<Tag>
	{
		public TagMap()
		{
			Map(x => x.Name);
			References(x => x.SystemUser);
		}
	}
}
