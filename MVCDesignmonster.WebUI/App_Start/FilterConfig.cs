using System.Web.Mvc;
using MVCDesignmonster.Service.Logging;

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
