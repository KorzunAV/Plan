using System.Web.Mvc;
using Common.Data.Core;
using Entities;
using MvcJqGrid;

namespace Client.Web.Controllers
{
    //[Authorize(Roles = Constants.Roles.AdminPrincipal)]
    //[IsInRole(new[] { Constants.Roles.AdminPrincipal, Constants.Roles.SuPrincipal })]
	public class CurrencyTypeController : BaseController<CurrencyTypeController>
	{
		public const string ListAction = "List";
		private IBaseDao Dao { get; set; }

		public CurrencyTypeController(IBaseDao dao)
		{
			Dao = dao;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult List(GridSettings gridSettings)
		{
            var condition = Helpers.GridHelper.ToSelectCondition(gridSettings);
            var items = Dao.SelectRange<CurrencyType>(condition);
            var jsonData = Helpers.GridHelper.GetJsonData(items, condition);
			return Json(jsonData, JsonRequestBehavior.AllowGet);
		}
	}
}
