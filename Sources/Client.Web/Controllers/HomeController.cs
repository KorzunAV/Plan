using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Web.Controllers
{
	public class HomeController : BaseController<HomeController>
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
