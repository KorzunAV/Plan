using System.Web.Mvc;
using System.Web.Security;

namespace Client.Web.ActionResults
{
    /// <summary>
    /// Redirect to login result actin result. The result redirects to login page using FormAuthentication
    /// </summary>
    public class RedirectToLoginResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}