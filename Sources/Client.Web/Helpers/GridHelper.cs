using System.Linq;
using Common.Data.Core;
using MvcJqGrid;

namespace Client.Web.Helpers
{
	public static class GridHelper
	{
		public static object GetJsonData<T>(PagedResult<T> items, GridSettings gridSettings)
			 where T : IEntityBase
		{
			var jsonData = new
		  {
			  total = items.ItemsCount / gridSettings.PageSize + 1,
			  page = gridSettings.PageIndex,
			  records = items.Result.Count,
			  rows = items.Result.ToArray()
		  };
			return jsonData;
		}
	}
}