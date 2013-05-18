using Entities.Entity;

namespace Data.NHibernate.Mappings
{
	public class TransferSubTypeMap : BaseMap<TransferSubType>
	{
		public TransferSubTypeMap()
		{
			Map(x => x.Name);
			References(x => x.TransferType);
		}
	}
}
