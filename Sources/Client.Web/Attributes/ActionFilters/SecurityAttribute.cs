using System;
using System.Threading;
using System.Web.Mvc;

namespace Client.Web.Attributes.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public abstract class SecurityAttribute : ActionFilterAttribute
    {
        public virtual bool HasPermission(ActionExecutingContext filterContext)
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated;
        }

        public abstract void ProccessNoPermissionResult(ActionExecutingContext filterContext);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!HasPermission(filterContext))
            {
                ProccessNoPermissionResult(filterContext);
            }
        }
    }
}