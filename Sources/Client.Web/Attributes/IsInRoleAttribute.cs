using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Client.Web.Attributes.ActionFilters;
using Common.Security;

namespace Client.Web.Attributes
{
	 public sealed class IsInRoleAttribute : SecurityAttribute
    {
        public List<string> Roles { get; protected set; }

        public IsInRoleAttribute(string role)
            : this(new[] { role })
        {
        }

        public IsInRoleAttribute(string[] roles)
        {
            Roles = new List<string>(roles);
        }

        public override bool HasPermission(ActionExecutingContext filterContext)
        {
            foreach (string role in Roles)
            {
                if (UserPrincipal.CurrentUser.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }

        public override void ProccessNoPermissionResult(ActionExecutingContext filterContext)
        {
            filterContext.Result = new NoPermissionsResult(Roles.ConvertAll(r => new Guid(r)));
        }
    }
}