using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Exeptions;
using NLog;

namespace Client.Web.Controllers
{
	public class BaseController<TController> : BaseController
		where TController : Controller
	{
		/// <summary>
		/// Gets mvc name of controller.
		/// </summary> 
		public static string Name
		{
			get
			{
				return GetControllerName(typeof(TController), true);
			}
		}

		protected override void HandleUnknownAction(string actionName)
		{
			base.HandleUnknownAction(actionName);
			this.View(actionName).ExecuteResult(this.ControllerContext);
		}
	}


	public class BaseController : Controller
	{
		private static Logger Log = LogManager.GetCurrentClassLogger();

		protected const string ModelStateKey = "7H5L1C3O-1L3I-2G45-I1TG-1K2Y6V71P5Y3";
		protected const string PreviousRouteDataKey = "35HUL25H-1L3I-G3L5-FG00-I33K20H32R66";
		protected const string CurrentRouteDataKey = "HT11F5FH-YU1K-G3L5-FG00-I33K20H32R5F";

		public const string IndexAction = "Index";
		public const string CurrentPage = "curPage";
		public const string ItemPerPage = "itemPerPage";

		public RouteValueDictionary PreviousRouteData
		{
			get { return (RouteValueDictionary)Session[PreviousRouteDataKey]; }
			set { Session[PreviousRouteDataKey] = value; }
		}

		public RouteValueDictionary CurrentRouteData
		{
			get { return (RouteValueDictionary)Session[CurrentRouteDataKey]; }
			set { Session[CurrentRouteDataKey] = value; }
		}

		#region [support]
		public static string GetControllerName(Type controllerType, bool removeControllerPostfix)
		{
			if (removeControllerPostfix)
			{
				return controllerType.Name.Replace("Controller", String.Empty);
			}
			return controllerType.Name;
		}

		protected virtual bool IsRequestOfType(HttpVerbs httpVerb)
		{
			return Request.RequestType == httpVerb.ToString().ToUpperInvariant();
		}

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{

			if (PreviousRouteData == null ||
				!Equals(CurrentRouteData.Count, filterContext.RouteData.Values.Count) ||
				!filterContext.RouteData.Values.Values.All(s => CurrentRouteData.Values.Contains(s)))
			{
				PreviousRouteData = CurrentRouteData;
				CurrentRouteData = filterContext.RouteData.Values;
			}


			if (!filterContext.IsChildAction)
			{
				var state = TempData[ModelStateKey] as ModelStateDictionary;
				if (state != null && !state.ContainsKey(ModelStateKey))
				{
					state.Add(ModelStateKey, new ModelState());
					foreach (var item in state)
					{
						if (!ModelState.ContainsKey(item.Key))
						{
							ModelState.Add(item);
						}
					}
					TempData[ModelStateKey] = null;
				}
			}

			base.OnActionExecuting(filterContext);
		}
		
		protected override void OnException(ExceptionContext filterContext)
		{
			if (filterContext.Exception != null)
			{
				if (filterContext.Exception is ValidationException)
				{
					foreach (var validationInfo in ((ValidationException)filterContext.Exception).ErrorInfos)
					{
						ModelState.AddModelError(validationInfo.Key, validationInfo.ErrorMessage);
						ModelState.AddModelError(string.Empty, validationInfo.ErrorMessage);
					}
					MoveInvalidModelStateToTempData(true);

					filterContext.Result = IsRequestOfType(HttpVerbs.Get) ? GetPreviousUrl() : GetCurrentUrl();

					filterContext.ExceptionHandled = true;
				}
				else
				{
					if (filterContext.Exception is BusinessExeption)
					{
						ModelState.AddModelError(string.Empty, ((BusinessExeption)filterContext.Exception).ErrorInfo.ErrorMessage);
						filterContext.Result = IsRequestOfType(HttpVerbs.Get) ? GetPreviousUrl() : GetCurrentUrl();
						filterContext.ExceptionHandled = true;
					}
					else
					{
						ModelState.AddModelError(string.Empty, Errors.UnknownError);
						MoveInvalidModelStateToTempData(true);

						Log.Error(filterContext.Exception.Message, filterContext.Exception);

						filterContext.Result = IsRequestOfType(HttpVerbs.Get) ? GetPreviousUrl() : GetCurrentUrl();
						filterContext.ExceptionHandled = true;
					}
				}
			}

			base.OnException(filterContext);
		}

		protected virtual void MoveActionParametersTempData(IDictionary<string, object> actionParameters)
		{
			if (actionParameters != null && actionParameters.Count > 0)
			{
				foreach (var param in actionParameters)
				{
					TempData[param.Key] = param.Value;
				}
			}
		}

		protected virtual void MoveInvalidModelStateToTempData(bool overwriteExistedModel)
		{
			if (!ModelState.IsValid)
			{
				var state = TempData[ModelStateKey] as ModelStateDictionary;
				if ((state == null || overwriteExistedModel) && !ModelState.ContainsKey(ModelStateKey))
				{
					TempData[ModelStateKey] = ModelState;
				}
			}
		}

		protected RedirectToRouteResult GetDefaultUrl()
		{
			if (CurrentRouteData != null)
			{
				return RedirectToRoute(CurrentRouteData);
			}
			return RedirectToAction(IndexAction, GetControllerName(typeof(HomeController), true));
		}

		protected RedirectToRouteResult GetPreviousUrl()
		{
			if (PreviousRouteData != null)
			{
				return RedirectToRoute(PreviousRouteData);
			}
			return GetDefaultUrl();
		}

		protected RedirectToRouteResult GetCurrentUrl()
		{
			if (CurrentRouteData != null)
			{
				return RedirectToRoute(CurrentRouteData);
			}
			return GetDefaultUrl();
		}

		protected RedirectToRouteResult Refresh()
		{
			return GetCurrentUrl();
		}
		#endregion
	}
}