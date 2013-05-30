namespace Common.Data.Core.Interfaces
{
	/// <summary>
	/// An object-oriented representation of a query criterion that may be used as a constraint
	/// in a <see cref="IFilter"/> query.
	/// </summary>
	public interface IExpression
	{
		/// <summary>
		/// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
		/// </summary>
		/// <param name="visitor"> конвертор </param>
		void AcceptConvert(IConvertor visitor);
	}
}
