using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// An Aggregation
	/// </summary>
	[Serializable]
    public class AggregateProjection : AbstractProjection
	{
		private string _propertyName;
		private string _aggregate;

		/// <summary>
		/// Имя свойства
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// Агрегация
		/// </summary>
		public string Aggregate
		{
			get { return _aggregate; }
			set { _aggregate = value; }
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="aggregate">Агрегация</param>
		/// <param name="propertyName">Имя свойства</param>
		protected internal AggregateProjection(string aggregate, string propertyName)
		{
			_aggregate = aggregate;
			_propertyName = propertyName;
		}

		/// <summary>
		/// Override для ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _aggregate + "(" + _propertyName + ')';
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public AggregateProjection()
		{
		}

		/// <summary>
		/// Does this projection specify grouping attributes?
		/// </summary>
		public override bool IsGrouped
		{
			get { return false; }
		}

		/// <summary>
		/// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
		/// </summary>
		/// <param name="visitor"> конвертор </param>
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
