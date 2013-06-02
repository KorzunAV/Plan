using System.Collections.Generic;

namespace Common.Data.Core
{
    public class SelectCondition
    {
        public SelectCondition()
            : this(10, 0) { }

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
        public IEnumerable<OrderBy> OrdersBy { get; set; }
        public Filter Where { get; set; }
    }
}
