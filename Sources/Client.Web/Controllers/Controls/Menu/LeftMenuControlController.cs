using System.Web.Mvc;
using Client.Web.Models.Controls.Menu;
using Common.Security;

namespace Client.Web.Controllers.Controls.Menu
{
    [AllowAnonymous]
    public class LeftMenuControlController : BaseController<LeftMenuControlController>
    {
        public const string LeftMenuControlPath = "Controls/Menu/LeftMenuControl";

        [ChildActionOnly]
        public PartialViewResult Index()
        {
            LeftMenuModel model = CreateModel();

            UpdateEnabledModules(model);

            return PartialView(LeftMenuControlPath, model);
        }

        protected virtual LeftMenuModel CreateModel()
        {
            return new LeftMenuModel();
        }

        protected virtual void UpdateEnabledModules(LeftMenuModel model)
        {
            model.HomeUrl = Url.Action(IndexAction, HomeController.Name);
            model.IsMyAccountEnabled = UserPrincipal.IsAuthenticated;
        }

    }
}