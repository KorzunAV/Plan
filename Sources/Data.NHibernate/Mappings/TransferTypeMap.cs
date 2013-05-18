using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class TransferTypeMap : BaseMap<TransferType>
	{
		public TransferTypeMap() {
			Map(x => x.Name);
		}
	}
}
