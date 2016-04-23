using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using MVCDesignmonster.Service.SessionStats;

namespace MVCDesignmonster.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            ActiveUserService.Instance.AddOneSession();
        }
        void Session_End(object sender, EventArgs e)
        {
            // Kommer åt sessionId efter det stängts
            var sessionId = this.Session.SessionID;

            ActiveUserService.Instance.RemoveOneSession(sessionId);
        }

       
    }
}
