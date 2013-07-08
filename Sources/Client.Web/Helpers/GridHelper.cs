using System.Linq;
using Common.Data.Core;
using Common.Data.Core.Conditions;
using MvcJqGrid;

namespace Client.Web.Helpers
{
    public static class GridHelper
    {
        public static SelectCondition ToSelectCondition(GridSettings gridSettings)
        {
            var result = new SelectCondition(gridSettings.PageSize, gridSettings.PageIndex);
            if (!string.IsNullOrEmpty(gridSettings.SortColumn))
            {
                result.OrdersBy.Add(new OrderBy(gridSettings.SortColumn, gridSettings.SortOrder));
            }
            if (gridSettings.Where != null)
            {

            }

            return result;
        }

        public static object GetJsonData<T>(PagedResult<T> items, SelectCondition selectCondition)
            where T : IEntityBase
        {
            var jsonData = new
                {
                    total = items.ItemsCount / selectCondition.PageSize + 1,
                    page = selectCondition.PageIndex,
                    records = items.Result.Count,
                    rows = items.Result.ToArray()
                };
            return jsonData;
        }
    }
}