using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MVCDesignmonster.Service.SessionStats
{
    public sealed class ActiveUserService
    {
        // TODO mark private after debug is done
        public HashSet<TrackedUser> _trackedUsers { get; set; } = new HashSet<TrackedUser>();

        private ActiveUserService()
        {
        }

        public static ActiveUserService Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ActiveUserService instance = new ActiveUserService();
        }

        public void AddOneSession()
        {
            var trackedUser = new TrackedUser()
            {
                SessionId = HttpContext.Current.Session.SessionID,
                UserName = HttpContext.Current.User.Identity.GetUserName(),
                TimeStampLastActive = DateTime.Now
            };

            // Rensar sessioner som mot förmodan buggat kvar
            var usersToRemove = new List<TrackedUser>();
            foreach (var user in _trackedUsers)
            {
                if ((DateTime.Now - user.TimeStampLastActive) > TimeSpan.FromMinutes(30))
                    usersToRemove.Add(user);
            }
            if (usersToRemove.Count > 0)
            {
                foreach (var user in usersToRemove)
                {
                    _trackedUsers.Remove(user);
                }
            }


            foreach (var user in _trackedUsers)
            {
                if (user.SessionId == trackedUser.SessionId)
                    return;
            }

            _trackedUsers.Add(trackedUser);
        }

        public void RemoveOneSession(string sessionId)
        {

            var trackedUser = _trackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
            if (trackedUser == null)
                return;

            _trackedUsers.Remove(trackedUser);
        }

        public void LoginSession(string userName)
        {
            var sessionId = System.Web.HttpContext.Current.Session.SessionID;

            var trackedUser = _trackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
            if (trackedUser == null)
                return;

            trackedUser.UserName = userName;
        }

        public void LogoutSession(string userName)
        {
            var sessionId = HttpContext.Current.Session.SessionID;

            var trackedUser = _trackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
            if (trackedUser == null)
                return;

            trackedUser.UserName = "";
        }

        public string GetSessionStats()
        {
            var sessions = _trackedUsers.Count;
            var loggedinSessions = _trackedUsers.Count(n => n.UserName != "");

            var sessionText = "aktiv session";
            var loggedonText = "påloggad";
            if (sessions > 1)
                sessionText = "aktiva sessioner";
            if (loggedinSessions > 1)
                loggedonText = "påloggade";


            return $"{sessions} {sessionText} varav {loggedinSessions} {loggedonText}.";
        }

        public void UpdateUserTimeStamp()
        {
            var sessionId = HttpContext.Current.Session.SessionID;

            var trackedUser = _trackedUsers.FirstOrDefault(n => n.SessionId == sessionId);
            if (trackedUser == null)
            {
                _trackedUsers.Add(new TrackedUser()
                {
                    SessionId = HttpContext.Current.Session.SessionID,
                    UserName = HttpContext.Current.User.Identity.GetUserName(),
                    TimeStampLastActive = DateTime.Now,
                });
                return;
            }

            trackedUser.TimeStampLastActive = DateTime.Now;
        }
    }
}
