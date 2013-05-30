using System.Collections.Generic;

namespace Common.Data.Core
{
    public class PagedResult<T>
        where T : IEntityBase
    {
        public PagedResult() 
            : this(new List<T>(), 0) { }

        public PagedResult(IList<T> result, long itemsCount)
        {
            Result = result;
            ItemsCount = itemsCount;
        }

        public IList<T> Result { get; set; }
        public long ItemsCount { get; set; }
    }
}
