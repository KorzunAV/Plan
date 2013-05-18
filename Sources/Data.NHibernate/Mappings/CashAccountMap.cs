using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class CashAccountMap : BaseMap<CashAccount>
	{
		public CashAccountMap() {
			Map(x => x.Name);
			References(x => x.SystemUser);
			Map(x => x.AccountBalance);
			Map(x => x.StartBalance);
			References(x => x.CurrencyType);
		}
	}
}
