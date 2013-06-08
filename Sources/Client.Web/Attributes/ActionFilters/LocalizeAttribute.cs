using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Client.Web.Attributes.ActionFilters
{
    //http://habrahabr.ru/post/86331/
    /// <summary>
    /// Определяет ресурсы какого языка подгружать
    /// </summary>
    public class LocalizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture = (filterContext.HttpContext.Session["culture"] != null)
                ? filterContext.HttpContext.Session["culture"].ToString()
                : "ru-RU";

            var cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            base.OnActionExecuting(filterContext);
        }
    }
}