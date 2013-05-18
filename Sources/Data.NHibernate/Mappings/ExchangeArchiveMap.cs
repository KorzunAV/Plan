using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class ExchangeArchiveMap : BaseMap<ExchangeArchive>
	{
		public ExchangeArchiveMap()
		{
			Map(x => x.Date);
			References(x => x.FirstCurrency);
			References(x => x.SecondCurrency);
			Map(x => x.Ratio);
		}
	}
}
