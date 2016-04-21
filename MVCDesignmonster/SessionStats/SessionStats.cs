using System.Collections.Generic;
using System.Linq;

namespace MVCDesignmonster.Singleton
{
    public class SessionStats
    {
        private static readonly SessionStats _instance = new SessionStats();
        //public int SessionCount { get; private set; } = 0;
        public List<TrackedUser> TrackedUsers { get; private set; } = new List<TrackedUser>();

        static SessionStats()
        {
            // Static constructor only gets called once.
            // + No need for locks in Instance-property!?
        }

        private SessionStats() { } //Redundant tror jag...

        public static SessionStats Instance
        {
            get
            {
                //if (_instance == null)
                //    _instance = new SessionStats();
                return _instance;
            }
        }

        public void AddOneSession()
        {
            var trackedUser = new TrackedUser()
            {
                SessionId = System.Web.HttpContext.Current.Session.SessionID,
                UserName = "Anonymous"
            };
            TrackedUsers.Add(trackedUser);
        }

        public void RemoveOneSession(string sessionId)
        {
            var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
            TrackedUsers.Remove(trackedUser);
        }

        public void LoginSession(string userName)
        {
            var sessionId = System.Web.HttpContext.Current.Session.SessionID;

            var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
            trackedUser.UserName = userName;
        }

        public void LogoutSession(string userName)
        {
            var sessionId = System.Web.HttpContext.Current.Session.SessionID;

            var trackedUser = TrackedUsers.SingleOrDefault(n => n.SessionId == sessionId);
            trackedUser.UserName = "Anonymous";
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
