using MVCDesignmonster.Logging;
using System.Web.Mvc;

namespace MVCDesignmonster.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilterAttribute());
        }
    }
}
