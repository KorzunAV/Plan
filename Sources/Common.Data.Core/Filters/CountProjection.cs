using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// A Count
	/// </summary>
	[Serializable]
    public class CountProjection : AggregateProjection
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public CountProjection()
		{
		}

		/// <summary>
		/// Дистинкт
		/// </summary>
		public bool Distinct
		{
			get { return _distinct; }
			set { _distinct = value; }
		}

		private bool _distinct;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="prop"></param>
		public CountProjection(String prop) : base("count", prop)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return (_distinct) ? "distinct " + base.ToString() : base.ToString();
		}

		/// <summary>
		/// count(distinct table.column)
		/// </summary>
		/// <returns></returns>
		public CountProjection SetDistinct()
		{
			_distinct = true;
			return this;
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
