using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MVCDesignmonster.Singleton
{
    public class SessionStats
    {
        private static readonly SessionStats _instance = new SessionStats();


        //TODO AHHHHH MÅSTE KOLLA MANUELLT SÅ INTE UserName Redan finns i TrackedUsers också! omfg
        // TODO MÅSTE TYVÄRR SKRIVA OM DET FRÅN GRUNDEN, DET ÄR INTE STABILT ATM.
        // OBS! Gör det enklare, behöver inte vara superrobust, rensar ju ändå upp vid session end.
        public HashSet<TrackedUser> TrackedUsers { get; private set; } = new HashSet<TrackedUser>();

        static SessionStats()
        {
        }

        private SessionStats() { }

        public static SessionStats Instance
        {
            get
            {
                return _instance;
            }
        }

        public void AddOneSession()
        {
            var username = HttpContext.Current.User.Identity.GetUserName();
            if (username == "")
                username = "Anonymous";

            var trackedUser = new TrackedUser()
            {
                SessionId = HttpContext.Current.Session.SessionID,
                UserName = username
            };

            foreach (var user in TrackedUsers)
            {
                if (user.SessionId == trackedUser.SessionId)
                    return;
            }

            TrackedUsers.Add(trackedUser);
        }

        public void RemoveOneSession(string sessionId)
        {
            try
            {
                var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
                if (trackedUser == null)
                    return;

                TrackedUsers.Remove(trackedUser);

            }
            catch (Exception)
            {
                throw;
                // Should log, not just throw!
            }
        }

        public void LoginSession(string userName)
        {
            try
            {
                var sessionId = System.Web.HttpContext.Current.Session.SessionID;

                var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
                if (trackedUser == null)
                    return;

                trackedUser.UserName = userName;
            }
            catch (Exception)
            {
                throw;
                // Should log, not just throw!
            }
        }

        public void LogoutSession(string userName)
        {
            try
            {
                var sessionId = System.Web.HttpContext.Current.Session.SessionID;

                var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
                if (trackedUser == null)
                    return;

                trackedUser.UserName = "Anonymous";
            }
            catch (Exception)
            {
                throw;
                // Should log, not just throw!
            }
        }

        public string GetSessionStats()
        {
            var sessions = TrackedUsers.Count;
            var loggedinSessions = TrackedUsers.Count(n => n.UserName != "Anonymous");
            return $"{sessions} aktiva sessioner varav {loggedinSessions} påloggade.";
        }

    }

    public class TrackedUser
    {
        public string SessionId { get; set; }
        public string UserName { get; set; }
    }



    // From C# In Depth
    public sealed class SingletonFullyLazy
    {
        private SingletonFullyLazy()
        {
        }

        public static SingletonFullyLazy Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SingletonFullyLazy instance = new SingletonFullyLazy();
        }
    }
}
