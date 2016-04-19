using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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

        // Session statistics
        private static List<string> _sessionInfo;
        private static readonly object padlock = new object();

        public static List<string> Sessions
        {
            get
            {
                lock (padlock)
                {
                    if (_sessionInfo == null)
                    {
                        _sessionInfo = new List<string>();
                    }
                    return _sessionInfo;
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // TODO Lägg till logik för att kolla så inte sessionen redan finns
            Sessions.Add(Session.SessionID);
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Sessions.Remove(Session.SessionID);
        }
    }
}
