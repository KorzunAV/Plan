using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.Security;
using Common.Web;

namespace Client.Web.Controllers
{
	public abstract class AuthControllerBase<TController> : BaseController<TController>
		where TController : Controller
	{
		public const string ReturnUrl = "ReturnUrl";

		public static void PrepareCookieForCurrentPrincipal(IApplicationStorage appStorage, HttpContextBase httpContext)
		{
			FormsAuthenticationTicket tempTicket = FormsAuthentication.Decrypt(FormsAuthentication.GetAuthCookie(UserPrincipal.CurrentUser.Identity.Name, false).Value);
			var authTicket = new FormsAuthenticationTicket(1,			// version
				UserPrincipal.CurrentUser.Identity.Name,				// username
				tempTicket.IssueDate,									// issue date
				tempTicket.Expiration,									// expiration
				false,													// persistance
				UserPrincipal.CurrentUser.SessionId.ToString(),			// session id
				FormsAuthentication.FormsCookiePath);					// cookie path

			// Encrypt the ticket
			string encrAuthTicket = FormsAuthentication.Encrypt(authTicket);
			// Build auth cookie
			var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrAuthTicket);
			appStorage[UserPrincipal.CurrentUser.SessionId.ToString()] = UserPrincipal.CurrentUser;
			httpContext.User = UserPrincipal.CurrentUser;
			httpContext.Response.Cookies.Add(authCookie);
		}

		protected ActionResult PostLogin(string returnUrl)
		{
			PrepareCookieForCurrentPrincipal(AppStorage, HttpContext);
			// TODO: HAL: If we use FormsAuthentication.RedirectFromLoginPage then we will not be able to implement test for the method.
			// Consider to use Mool library to mock static methods or introduce additional abstractin layer to incapsulate FormsAuthentication methods
			if (!String.IsNullOrEmpty(returnUrl))
			{
				Uri returnUri = new Uri(returnUrl, UriKind.RelativeOrAbsolute);
				if (!returnUri.IsAbsoluteUri)
				{
					return Redirect(returnUrl);
				}
				Uri requestUrl = Request.Url;
				if (requestUrl != null)
				{
					string requestHost = requestUrl.Host;
					if (returnUri.Host == requestHost)
					{
						return Redirect(returnUrl);
					}
				}
			}
			return GetDefaultRedirectResult();
		}

		protected RedirectToRouteResult GetDefaultRedirectResult()
		{
			return RedirectToRoute(HomeController.Name, IndexAction);
		}

		protected RedirectToRouteResult GetLoginRedirectResult(string returnUrl)
		{
			if (String.IsNullOrEmpty(returnUrl))
			{
				return RedirectToRoute(AuthController.Name, IndexAction);
			}
			return
				new RedirectToRouteResult(new RouteValueDictionary
                                                  {
                                                      {Constants.RouteKeys.Controller, AuthController.Name},
                                                      {Constants.RouteKeys.Action, IndexAction},
                                                      {ReturnUrl, returnUrl}
                                                  });
		}
	}
}