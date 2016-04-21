using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using MVCDesignmonster.Singleton;

namespace MVCDesignmonster.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // TODO Eller ska man ha en instans... troligen inte
        //public SessionStats SessionStatsSingleTon = SessionStats.Instance;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //SessionStatsSingleTon = SessionStats.Instance;
        }

        void Session_Start(object sender, EventArgs e)
        {
            SessionStats.Instance.AddOneNewSession();
        }
        void Session_End(object sender, EventArgs e)
        {
            // TODO en dictionary/List<TrackedUser> som länkar samman SessionId med UserId,
            // på så sätt kan man ju ta bort inloggad user när dom bara kryssar rutan...
            // -> SessionStats.Instance.RemoveUserWithSessionId == SessionID som stängs
            SessionStats.Instance.RemoveOneNewSession();
            //SessionStatsSingleTon.RemoveOneNewSession();
        }

        // OLD VERSION 2
        //void Session_Start(object sender, EventArgs e)
        //{
        //    Application.Lock();
        //    Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
        //    Application.UnLock();
        //}
        //void Session_End(object sender, EventArgs e)
        //{
        //    Application.Lock();
        //    Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
        //    Application.UnLock();
        //}


        //// OLD VERSION !
        //private static List<string> _sessionInfo;
        //private static readonly object padlock = new object();

        //public static List<string> Sessions
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (_sessionInfo == null)
        //            {
        //                _sessionInfo = new List<string>();
        //            }
        //            return _sessionInfo;
        //        }
        //    }
        //}

        //protected void Session_Start(object sender, EventArgs e)
        //{
        //    // TODO Lägg till logik för att kolla så inte sessionen redan finns
        //    Sessions.Add(Session.SessionID);
        //}
        //protected void Session_End(object sender, EventArgs e)
        //{
        //    Sessions.Remove(Session.SessionID);
        //}
    }
}
