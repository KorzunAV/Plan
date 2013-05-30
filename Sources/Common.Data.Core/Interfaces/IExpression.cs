namespace Common.Data.Core.Interfaces
{
	/// <summary>
	/// An object-oriented representation of a query criterion that may be used as a constraint
	/// in a <see cref="IFilter"/> query.
	/// </summary>
	public interface IExpression
	{
		/// <summary>
		/// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
		/// </summary>
		/// <param name="visitor"> ��������� </param>
		void AcceptConvert(IConvertor visitor);
	}
}
