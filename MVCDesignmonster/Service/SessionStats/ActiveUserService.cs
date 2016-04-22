using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MVCDesignmonster.Service.SessionStats
{
    public class ActiveUserService
    {
        private static readonly ActiveUserService _instance = new ActiveUserService();

        public HashSet<TrackedUser> TrackedUsers { get; private set; } = new HashSet<TrackedUser>();

        static ActiveUserService() { }

        private ActiveUserService() { }

        public static ActiveUserService Instance
        {
            get
            {
                return _instance;
            }
        }

        public void AddOneSession()
        {
            try
            {
                var username = HttpContext.Current.User.Identity.GetUserName();

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
            catch (Exception)
            {
                throw;
                // Should log, not just throw!
            }

        }

        public void RemoveOneSession(string sessionId)
        {
            try
            {
                var trackedUser = TrackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
                //if (trackedUser == null)
                //    return;

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

                var trackedUser = TrackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
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
                var sessionId = HttpContext.Current.Session.SessionID;

                var trackedUser = TrackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
                if (trackedUser == null)
                    return;

                trackedUser.UserName = "";
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
            var loggedinSessions = TrackedUsers.Count(n => n.UserName != "");

            var sessionText = "aktiv session";
            var loggedonText = "påloggad";
            if (sessions > 1)
                sessionText = "aktiva sessioner";
            if (loggedinSessions > 1)
                loggedonText = "påloggade";


            return $"{sessions} {sessionText} varav {loggedinSessions} {loggedonText}.";
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
