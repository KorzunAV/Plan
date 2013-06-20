using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Exeptions;

namespace Client.Web.Controllers
{
	[Attributes.ActionFilters.AllowAnonymous]
	public class AuthController : AuthControllerBase<AuthController>
	{
		public const string WebServiceIsNotAvailableSR = "WebServiceIsNotAvailable";

		public const string LogoutAction = "Logout";
		public const string AcceptTermsOfUseAction = "AcceptTermsOfUse";

		public const string UserAcceptsTermsOfUseAction = "UserAcceptsTermsOfUse";
		public const string UserDeclinesTermsOfUseAction = "UserDeclinesTermsOfUse";

		public const string TermsOfUserControlPath = "Controls/Login/AcceptTermsOfUseControl";

		protected AuthBlo AuthBlo { get; set; }

		protected ConfigurationBlo ConfigurationBlo { get; set; }


		public AuthController(AuthBlo authBlo, ConfigurationBlo configurationBlo)
		{
			AuthBlo = authBlo;
			ConfigurationBlo = configurationBlo;
		}

		[HttpGet]
		public virtual ViewResult Index()
		{
			return View(new UserLoginModel { ReturnUrl = Request.QueryString[ReturnUrl], IsSignUpEnabled = ConfigurationBlo.IsSignUpEnabled });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(UserLoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(IndexAction, Name);
			}
			try
			{
				AuthBlo.Login(model.Username, model.Password);
				return PostLogin(model.ReturnUrl);
			}
			catch (ValidationException ex)
			{
				ModelState.MergeValidationException(ex);
				return RedirectToAction(IndexAction, Name);
			}
			// HAL: I think it would be more correctly to catch specific messages to indicate service unavailability than catch DataException. But it requires more time to do it :-)
			catch (DataException ex)
			{
				Log.Error(ex.Message, ex);
				ModelState.AddModelError(ResourceProvider.GetResourceString(WebServiceIsNotAvailableSR));
				return RedirectToAction(IndexAction, Name);
			}
		}

		[HttpGet]
		public virtual RedirectToRouteResult Logout()
		{
			return LogoutAndRedirectToDefault();
		}

		[HttpGet, ChildActionOnly]
		public PartialViewResult AcceptTermsOfUse()
		{
			return PartialView(TermsOfUserControlPath);
		}

		[HttpPost]
		public void UserAcceptsTermsOfUse()
		{
			AuthBlo.AcceptTermsOfUse();
		}

		[HttpPost]
		public RedirectToRouteResult UserDeclinesTermsOfUse()
		{
			return LogoutAndRedirectToDefault();
		}

		[NonAction]
		public bool IsSessionActive(Guid sessionId)
		{
			return AuthBlo.IsSessionActive(sessionId);
		}

		#region Aux methods

		private RedirectToRouteResult LogoutAndRedirectToDefault()
		{
			AuthBlo.Logout();
			FormsAuthentication.SignOut();
			return GetDefaultRedirectResult();
		}

		#endregion
	}

}