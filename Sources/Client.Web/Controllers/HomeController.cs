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

        //public ActionResult SetCulture(string culture)
        //{
        //    culture = CultureHelper.GetValidCulture(culture);

        //    HttpCookie cookie = Request.Cookies["_culture"];
        //    if (cookie != null)
        //    {
        //        cookie.Value = culture;
        //    }
        //    else
        //    {
        //        cookie = new HttpCookie("_culture")
        //                     {
        //                         HttpOnly = false,
        //                         Value = culture,
        //                         Expires = DateTime.Now.AddYears(1)
        //                     };
        //    }
        //    Response.Cookies.Add(cookie);
        //    return Refresh();
        //}
	}
}
