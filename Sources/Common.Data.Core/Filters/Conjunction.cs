using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// An <see cref="AbstractExpression"/> that Junctions together multiple 
	/// <see cref="AbstractExpression"/>s with an <c>and</c>
	/// </summary>
	[Serializable]
    public class Conjunction : Junction
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public Conjunction()
		{
		}

		/// <summary>
		/// Get the Sql operator to put between multiple <see cref="AbstractExpression"/>s.
		/// </summary>
		/// <value>The string "<c> and </c>"</value>
		protected override string Op
		{
			get { return " and "; }
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
