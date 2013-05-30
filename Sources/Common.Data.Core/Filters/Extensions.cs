
namespace Common.Data.Core.Filters
{
    public static class Extensions
    {
        /// <summary>
        /// Set a limit upon the number of objects to be retrieved
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="maxResult"></param>
        public static Filter MaxResult(this Filter filter, int maxResult)
        {
            filter.MaxResult = maxResult;
            return filter;
        }

        /// <summary>
        /// Set the first result to be retrieved
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="firstResult"></param>
        public static Filter FirstResult(this Filter filter, int firstResult)
        {
            filter.FirstResult = firstResult;
            return filter;
        }
    
    
    }
}
