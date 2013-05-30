using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// An <see cref="AbstractExpression"/> that Junctions together multiple 
	/// <see cref="AbstractExpression"/>s with an <c>or</c>
	/// </summary>
	/// <remarks>If empty add 1=0 to WHERE expression</remarks>
	[Serializable]
    public class Disjunction : Junction
	{
		/// <summary>
		/// �����������
		/// </summary>
		public Disjunction()
		{
		}

		/// <summary>
		/// Get the Sql operator to put between multiple <see cref="AbstractExpression"/>s.
		/// </summary>
		/// <value>The string "<c> or </c>"</value>
		protected override string Op
		{
			get { return " or "; }
		}


		/// <summary>
		/// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
		/// </summary>
		/// <param name="visitor"> ��������� </param>
        [CLSCompliant(false)]
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
