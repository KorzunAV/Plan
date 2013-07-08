using System.Collections.Generic;

namespace Common.Data.Core.Conditions
{
    /// <summary>
    /// Условия ограничения выборки
    /// </summary>
    public class SelectCondition
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SelectCondition()
            : this(10, 1) { }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pageSize">Количество записей на странице.</param>
        /// <param name="pageIndex">Номер страницы начиная с единицы.</param>
        public SelectCondition(int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            OrdersBy = new List<OrderBy>();
            Where = new Filter();
        }
        
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IList<OrderBy> OrdersBy { get; set; }
        public Filter Where { get; set; }
    }
}
