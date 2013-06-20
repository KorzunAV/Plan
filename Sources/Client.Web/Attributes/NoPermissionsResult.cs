using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Client.Web.Controllers;
using NLog;

namespace Client.Web.Attributes
{
	/// <summary>
	/// Result to inform that you have not enough permission to execute action. In many cases the result will be used as security issue
	/// </summary>
	public class NoPermissionsResult : CustomErrorResult
	{
		private string _errorMessage;
		private List<Guid> _permissions;
		private SecurityException _exception;

		public NoPermissionsResult(string errorMessage, SecurityException exception, List<Guid> permissions)
		{
			_errorMessage = errorMessage;
			_exception = exception;
			_permissions = permissions;
		}

		public NoPermissionsResult()
			: this(String.Empty, null, null)
		{
		}

		public NoPermissionsResult(string errorMessage)
			: this(errorMessage, null, null)
		{
		}

		public NoPermissionsResult(SecurityException exception)
			: this(String.Empty, exception, null)
		{
		}

		public NoPermissionsResult(List<Guid> permissions)
			: this(String.Empty, null, permissions)
		{
		}

		private string BuildErrorMessage(ControllerContext context)
		{
			var errorBuilder = new StringBuilder();

			errorBuilder.AppendLine(String.Format("No permission to execute the following url: {0}", context.HttpContext.Request.RawUrl));

			if (!String.IsNullOrEmpty(_errorMessage))
			{
				errorBuilder.AppendLine(String.Format("  - The following security error has been occured: {0}",
													  _errorMessage));
			}
			if (_permissions != null && _permissions.Count > 0)
			{
				errorBuilder.AppendFormat("  - You have not permissions/roles to execute the following actions: {0}",
										 _permissions[0]);
				for (int i = 1; i < _permissions.Count; i++)
				{
					errorBuilder.AppendFormat(", {0}", _permissions[i]);
				}
				errorBuilder.AppendLine(String.Empty);
			}
			if (_exception != null)
			{
				errorBuilder.AppendLine("  - The following security exception has been occured:");
				errorBuilder.AppendLine(_exception.ToString());
				errorBuilder.AppendLine(String.Empty);
			}
			return errorBuilder.ToString();
		}

		public override void ExecuteResult(ControllerContext context)
		{
			// Set error statuc code as 403 Forbidden. For details see the following link: http://en.wikipedia.org/wiki/List_of_HTTP_status_codes
			SetErrorResponse(context, HttpStatusCode.Forbidden);
			var log = LogManager.GetCurrentClassLogger();
			log.Error(BuildErrorMessage(context));
			// HAL: It is tempopary implementation. Separate view should be implemented
			var route = new RouteValueDictionary(new Dictionary<string, object>
                                             {
                                                 {Constants.RouteKeys.Controller, ErrorsController.Name},
                                                 {Constants.RouteKeys.Action, ErrorsController.NoPermissionAction},
                                                 {Constants.RouteKeys.AspxErrorPath, context.HttpContext.Request.RawUrl}
                                             });
			var result = new RedirectToRouteResult(route);
			result.ExecuteResult(context);
		}
	}
}