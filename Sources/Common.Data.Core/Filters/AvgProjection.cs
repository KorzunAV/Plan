using System;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// AVG aggregate function
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Avg", Justification = "Standard shortage"), Serializable]
    public class AvgProjection : AggregateProjection
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="propertyName">Имя свойства</param>
		public AvgProjection(String propertyName)
			: base("avg", propertyName)
		{
		}
		
		/// <summary>
		/// Контруктор
		/// </summary>
		public AvgProjection()
		{
		}
	}
}
