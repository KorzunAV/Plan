using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// An identifier constraint
	/// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eq", Justification = "Standard shortage"), Serializable]
    public class IdentifierEqExpression : AbstractExpression
	{
		private readonly object value;
        
		public object Value
		{
			get { return value; }
		}

		/// <summary>
		/// �����������
		/// </summary>
		/// <param name="value">�������������</param>
		public IdentifierEqExpression(object value)
		{
			this.value = value;
		}

		#region AbstractExpression Members

		/// <summary>
		/// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
		/// </summary>
		/// <param name="visitor"> ��������� </param>
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}

		#endregion
	}
}
