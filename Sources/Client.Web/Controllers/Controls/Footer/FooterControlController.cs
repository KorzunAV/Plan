using System.Web.Mvc;
using Client.Web.Models.Controls.Footer;

namespace Client.Web.Controllers.Controls.Footer
{
    [AllowAnonymous]
    public class FooterControlController : BaseController<FooterControlController>
    {
        public const string FooterControlPath = "Controls/FooterControl";

        [ChildActionOnly]
        public PartialViewResult Index()
        {
            FooterModel model = CreateModel();

            UpdateEnabledModules(model);
            return PartialView(FooterControlPath, model);
        }

        protected virtual FooterModel CreateModel()
        {
            return new FooterModel();
        }

        protected virtual void UpdateEnabledModules(FooterModel model)
        {
            model.HomeUrl = Url.Action(IndexAction, HomeController.Name);

            model.IsMyAccountEnabled = ModulesSecurity.IsModuleVisible(ModuleOptionPermissions.MODULE_ID_MY_ACCOUNT_GUID);
        }
    }
}
