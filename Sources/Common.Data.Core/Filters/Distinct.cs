using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// Distinct
	/// </summary>
	[Serializable]
    public class Distinct : AbstractProjection
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public Distinct()
		{
		}

		private AbstractProjection _projection;
		/// <summary>
		/// Проекция
		/// </summary>
		public AbstractProjection Projection
		{
			get { return _projection; }
			set { _projection = value; }
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public Distinct(AbstractProjection projection)
		{
			_projection = projection;
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
        [CLSCompliant(false)]
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
