using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class СashTransferMap : BaseMap<СashTransfer>
	{
		public СashTransferMap()
		{
			Map(x => x.TransferCount);
			References(x => x.CurrencyType);
			References(x => x.SenderCashAccount);
			References(x => x.ReceiverCashAccount);
			References(x => x.TransferType);
			Map(x => x.Comment);

			HasMany(x => x.Tags).Cascade.All();

			References(x => x.TransferSubType);
		}
	}
}
