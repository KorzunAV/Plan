﻿using System.Collections.Generic;

namespace Entities.Entity
{
	/// <summary>
	/// Денежный перевод
	/// </summary>
	public class CashTransfer : EntityBase
	{
		/// <summary>
		/// Размер перевода.
		/// </summary>
		public virtual decimal TransferCount { get; set; }
		
		/// <summary>
		/// Валюта перевода.
		/// </summary>
		public virtual CurrencyType CurrencyType { get; set; }
		
		/// <summary>
		/// Счет отправителя
		/// </summary>
		public virtual CashAccount SenderCashAccount { get; set; }

		/// <summary>
		/// Счет получателя
		/// </summary>
		public virtual CashAccount ReceiverCashAccount { get; set; }
		
		/// <summary>
		/// Тип перевода
		/// </summary>
		public virtual TransferType TransferType { get; set; }

		/// <summary>
		/// Комментарий.
		/// </summary>
		public virtual string Comment { get; set; }

		/// <summary>
		/// Пользовательские теги.
		/// </summary>
		public virtual ICollection<Tag> Tags { get; set; }
		
		/// <summary>
		/// Подтип денежного перевода.
		/// </summary>
		public virtual TransferSubType TransferSubType { get; set; }
	}
}