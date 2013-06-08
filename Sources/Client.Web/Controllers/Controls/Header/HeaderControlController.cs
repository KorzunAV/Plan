using System.Web.Mvc;

namespace Client.Web.Controllers.Controls.Header
{
    [AllowAnonymous]
    public class HeaderControlController : BaseController<HeaderControlController>
    {
        private const string HeaderControlPath = "Controls/Header/HeaderControl";

        [ChildActionOnly]
        public PartialViewResult Index()
        {
            return PartialView(HeaderControlPath);
        }
    }
}