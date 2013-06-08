using System.Web.Mvc;

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
            return (html.ViewContext.HttpContext.GetGlobalResourceObject(ResourcesHelper.GetViewSourceName, key) ?? key) as string;
            //return html.Resource(ResourcesHelper.GetViewSourceName, key);

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
            //return html.Resource("Images", key);
        }

        #endregion
    }
}