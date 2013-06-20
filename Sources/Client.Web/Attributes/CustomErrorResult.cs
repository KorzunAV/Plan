using System.Net;
using System.Web.Mvc;

namespace Client.Web.Attributes
{
	public abstract class CustomErrorResult : ActionResult
    {
        protected void SetErrorResponse(ControllerContext context, HttpStatusCode statusCode)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.StatusCode = (int)statusCode;

            // Certain versions of IIS will sometimes use their own error page when
            // they detect a server error. Setting this property indicates that we
            // want it to try to render ASP.NET MVC's error page instead.
            context.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}