using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// Проекция для свойства
	/// </summary>
	[Serializable]
    public class PropertyProjection : AbstractProjection
	{
		private string _propertyName;
		private bool _grouped;

		/// <summary>
		/// Конструктор
		/// </summary>
		public PropertyProjection()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="propertyName">Имя свойства</param>
		/// <param name="grouped">Группировать</param>
		public PropertyProjection(string propertyName, bool grouped)
		{
			_propertyName = propertyName;
			_grouped = grouped;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="propertyName">Имя свойства</param>
		public PropertyProjection(string propertyName)
			: this(propertyName, false)
		{
		}

		/// <summary>
		/// Имя свойства
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _propertyName;
		}

		/// <summary>
		/// Группировать
		/// </summary>
		public override bool IsGrouped
		{
			get { return _grouped; }
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
