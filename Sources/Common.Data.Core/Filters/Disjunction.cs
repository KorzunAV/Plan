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
		/// Конструктор
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
		/// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
		/// </summary>
		/// <param name="visitor"> конвертор </param>
        [CLSCompliant(false)]
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
