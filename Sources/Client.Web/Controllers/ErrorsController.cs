using System.Web.Mvc;


namespace Client.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorsController : BaseController<ErrorsController>
	{
		#region [Action]

		public const string PageNotFoundAction = "PageNotFound";
		public const string UnknownAction = "Unknown";
		public const string ObjectNotFoundAction = "ObjectNotFound";
		public const string NoPermissionAction = "NoPermission";

		#endregion [Action]


		[HttpGet]
		public ViewResult PageNotFound()
		{
			return View();
		}

		[HttpGet]
		public ViewResult Unknown()
		{
			return View();
		}

		[HttpGet]
		public ViewResult ObjectNotFound()
		{
			return View();
		}

		[HttpGet]
		public ViewResult NoPermission()
		{
			return View();
		}
	}
}