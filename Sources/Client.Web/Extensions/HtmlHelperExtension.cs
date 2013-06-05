using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;


namespace Client.Web.Extensions
{
    /// <summary>
    /// Extension class for HtmlHelper
    /// </summary>
    public static class HtmlHelperExtension
    {
        #region [Resources]

        /// <summary>
        ///     Gets string resource from global resources.
        /// </summary>
        public static string Resource(this HtmlHelper html, string key)
        {
            return (html.ViewContext.HttpContext.GetGlobalResourceObject(string.Empty, key) ?? key) as string;
        }
        /// <summary>
        ///     Gets resource from global resources.
        /// </summary>
        public static string Resource(this HtmlHelper html, string classKey, string key)
        {
            return (html.ViewContext.HttpContext.GetGlobalResourceObject(classKey, key) ?? key) as string;
        }
        /// <summary>
        ///     Gets resource from global resources.
        /// </summary>
        public static string ImageResource(this HtmlHelper html, string key)
        {
            return (html.ViewContext.HttpContext.GetGlobalResourceObject("Images", key) ?? key) as string;
        }

        #endregion
    }
}