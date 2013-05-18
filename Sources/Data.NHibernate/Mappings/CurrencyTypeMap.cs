using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class CurrencyTypeMap : BaseMap<CurrencyType>
	{
		public CurrencyTypeMap() {
			Map(x => x.Name);
		}
	}
}
