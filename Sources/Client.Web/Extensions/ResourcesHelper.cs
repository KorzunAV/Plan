using Common.Security;
using Resources;

namespace Client.Web.Extensions
{
    public class ResourcesHelper
    {
        public static string GetViewSourceName
        {
            get
            {
                switch (UserPrincipal.GetCulture)
                {
                    case Culture.CultureType.Ru:
                        {
                            return typeof(Views).Name;
                        }
                    default:
                        {
                            return typeof(Views).Name;
                        }
                }
            }
        }
    }
}