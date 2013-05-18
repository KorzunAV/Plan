namespace Entities.Entity
{
	/// <summary>
	/// Тип денежного перевода.
	/// </summary>
	public class TransferType : EntityBase
	{
		/// <summary>
		/// Название
		/// </summary>
		public virtual string Name { get; set; }
	}
}