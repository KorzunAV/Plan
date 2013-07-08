using System.Globalization;
using System.Web.Mvc;
using Common.Data.Core;
using MvcJqGrid;
using Entities;
using System.Linq;

namespace Client.Web.Controllers
{
    //[Attributes.ActionFilters.Localize]
    //[Authorize]
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
            var condition = Helpers.GridHelper.ToSelectCondition(gridSettings);
            var items = Dao.SelectRange<Transaction>(condition);

            var jsonData = new
                {
                    total = items.ItemsCount / condition.PageSize + 1,
                    page = condition.PageIndex,
                    records = items.ItemsCount,
                    rows = (items.Result.Select(i => new
                        {
                            id = i.Id, // Remove ravendb prefix from identifier
                            cell = new[]
                                {
                                    (i.RegistrationDate.HasValue ? i.RegistrationDate.Value.ToShortDateString() : string.Empty),
                                    (i.TransactionDate.HasValue ? i.TransactionDate.Value.ToShortDateString() : string.Empty),
                                    i.TransactionNumber,
                                    i.TransactionCode,
                                    (i.CurrencyType != null ? i.CurrencyType.Name : string.Empty),
                                    i.Value.ToString(CultureInfo.InvariantCulture),
                                    (i.TransferType != null ? i.TransferType.Name : string.Empty),
                                    i.Comment,
                                    (i.TransferSubType != null ? i.TransferSubType.Name : string.Empty),
                                }
                        })).ToArray()
                };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
