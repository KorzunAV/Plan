namespace Entities
{
	/// <summary>
	/// Подвид денежного перевода.
	/// </summary>
	public class TransferSubType : EntityBase
	{
		/// <summary>
		/// Название
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Тип денежного перевода.
		/// </summary>
		public virtual TransferType TransferType { get; set; }
	}
}