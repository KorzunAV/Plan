using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
    ///<summary>
    /// Абстрактный класс для всех выражений используемых для поиска в фильтрах
    ///</summary>
    [Serializable]
    public abstract class AbstractExpression : IExpression
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AbstractExpression() { }

        #region IExpression Members

        /// <summary>
        /// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
        /// </summary>
        /// <param name="visitor"> конвертор </param>
        public abstract void AcceptConvert(IConvertor visitor);

        #endregion
    }
}
