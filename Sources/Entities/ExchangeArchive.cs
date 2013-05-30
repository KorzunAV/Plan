using System;

namespace Entities
{
	/// <summary>
	/// Архив курсов валют
	/// </summary>
	public class ExchangeArchive : EntityBase
	{
		/// <summary>
		/// Дата регистрации.
		/// </summary>
		public virtual DateTime Date { get; set; }
		
		/// <summary>
		/// Название основной валюты
		/// </summary>
		public virtual CurrencyType FirstCurrency { get; set; }
		
		/// <summary>
		/// Название второй валюты
		/// </summary>
		public virtual CurrencyType SecondCurrency { get; set; }

		/// <summary>
		/// Величена соотношения валют. FirstCurrency / SecondCurrency
		/// </summary>
		public virtual decimal Ratio { get; set; }
	}
}