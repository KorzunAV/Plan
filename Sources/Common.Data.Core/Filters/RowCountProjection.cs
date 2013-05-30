using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// count(*)
	/// </summary>
	[Serializable]
    [CLSCompliant(false)]
	public class RowCountProjection : AbstractProjection
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public RowCountProjection()
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
        [CLSCompliant(false)]
        public override void AcceptConvert(IConvertor visitor)
		{
            //TODO: CR: PYA: NotSupported or InvalidOperation?
            //TODO: CR: PYA-FIX: 
			throw new NotSupportedException("Convert of objects of this class not supported by IConvertor");
		}
	}
}
