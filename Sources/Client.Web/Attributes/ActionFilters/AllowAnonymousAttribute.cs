using System.Web.Mvc;

namespace Client.Web.Attributes.ActionFilters
{
    /// <summary>
    /// The attribute will definitly localize controllers and actions which do not need have security or have anonymous access
    /// </summary>
    public sealed class AllowAnonymousAttribute : SecurityAttribute
    {
        public override bool HasPermission(ActionExecutingContext filterContext)
        {
            return true;
        }

        public override void ProccessNoPermissionResult(ActionExecutingContext filterContext)
        {
        }
    }
}