using System.Linq;
using System.Web.Mvc;
using Common.Data.Core;
using MvcJqGrid;
using Entities;
using Ninject;

namespace Client.Web.Controllers
{
    public class TestGridController : BaseController<TestGridController>
    {
        public const string ListAction = "List";

        protected IBaseDao Dao { get { return Kernel.Get<IBaseDao>(); } }

        public ActionResult Index()
        {
            return RedirectToAction(ListAction, new GridSettings());
        }

        public ActionResult List(GridSettings gridSettings)
        {
            var items = Dao.SelectRange<UserRole>(new SelectCondition());

            var jsonData = new
            {
                total = items.ItemsCount / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = items.Result.Count,
                rows = items.Result.ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
