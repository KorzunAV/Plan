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
		/// �����������
		/// </summary>
		/// <param name="propertyName">��� ��������</param>
		public AvgProjection(String propertyName)
			: base("avg", propertyName)
		{
		}
		
		/// <summary>
		/// ����������
		/// </summary>
		public AvgProjection()
		{
		}
	}
}
