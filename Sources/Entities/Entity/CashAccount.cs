namespace Entities.Entity
{
	/// <summary>
	/// Счет пользователя. Банковский или наличный.
	/// </summary>
	public class CashAccount : EntityBase
	{
		/// <summary>
		/// Имя счета.
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Владелец счета.
		/// </summary>
		public virtual SystemUser SystemUser { get; set; }

		/// <summary>
		/// Текущее состояние счета.
		/// </summary>
		public virtual decimal AccountBalance { get; set; }

		/// <summary>
		/// Начально состояние счета.
		/// </summary>
		public virtual decimal StartBalance { get; set; }
		
		/// <summary>
		/// Тип вылюты счета.
		/// </summary>
		public virtual CurrencyType CurrencyType { get; set; }
	}
}