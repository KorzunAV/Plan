using System.Web.Mvc;

namespace Client.Web.Controllers
{
    [Attributes.ActionFilters.Localize]
    [Attributes.ActionFilters.AllowAnonymous]
    public class HomeController : BaseController<HomeController>
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
