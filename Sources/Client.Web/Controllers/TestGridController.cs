using System.Linq;
using System.Web.Mvc;
//using Entities.Entity;
using MvcJqGrid;

namespace Client.Web.Controllers
{
	//public class TestGridController : BaseController<TestGridController>
	//{
	//    protected IBaseDao Dao { get; set; }

	//    public TestGridController(IBaseDao dao)
	//    {
	//        Dao = dao;
	//    }

	//    //
	//    // GET: /TestGrid/

	//    public ActionResult Index()
	//    {
	//        return View();
	//    }

	//    public ActionResult List(GridSettings gridSettings)
	//    {
	//        CustomerRepository repository = new CustomerRepository();
	//        string name = string.Empty;
	//        string company = string.Empty;

	//        if (gridSettings.IsSearch)
	//        {
	//            name = gridSettings.Where.rules.Any(r => r.field == "Name") ?
	//                   gridSettings.Where.rules.FirstOrDefault(r => r.field == "Name").data :
	//                   string.Empty;
	//            company = gridSettings.Where.rules.Any(r => r.field == "Company") ?
	//                gridSettings.Where.rules.FirstOrDefault(r => r.field == "Company").data :
	//                string.Empty;
	//        }

	//        var customers = repository.List(name, company, gridSettings.SortColumn, gridSettings.SortOrder);
	//        int totalCustomers = customers.Count;
	//        var jsonData = new
	//        {
	//            total = totalCustomers / gridSettings.PageSize + 1,
	//            page = gridSettings.PageIndex,
	//            records = totalCustomers,
	//            rows = (
	//                    from c in customers
	//                    select new
	//                    {
	//                        id = c.CustomerID,
	//                        cell = new[]
	//                {
	//                    c.CustomerID.ToString(),
	//                    string.Format("{0} {1}", c.FirstName, c.LastName),
	//                    c.CompanyName,
	//                    c.EmailAddress
	//                }
	//                    }).ToArray()
	//        };

	//        return Json(jsonData, JsonRequestBehavior.AllowGet);
	//    }
	//}
}
