using System.Collections.Generic;

namespace Common.Data.Core
{
    public class SelectCondition
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<OrderBy> OrdersBy { get; set; }
        public Filter Where { get; set; }
    }
}
