using System.Web.Mvc;
using Common.Data.Core;
using MvcJqGrid;
using Entities;

namespace Client.Web.Controllers
{
    [Attributes.ActionFilters.Localize]
    [Authorize]
    public class MainGridController : BaseController<MainGridController>
    {
        public const string ListAction = "List";
        public const string ImportFromFileAction = "ImportFromFile";
        private IBaseDao Dao { get; set; }

        public MainGridController(IBaseDao dao)
        {
            Dao = dao;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(GridSettings gridSettings)
        {
            var items = Dao.SelectRange<CashTransfer>(new SelectCondition());
            var jsonData = Helpers.GridHelper.GetJsonData(items, gridSettings);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
