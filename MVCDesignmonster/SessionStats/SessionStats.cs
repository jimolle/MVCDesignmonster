using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDesignmonster.Singleton
{
    public class SessionStats
    {
        private static readonly SessionStats _instance = new SessionStats();
        public int SessionCount { get; private set; } = 0;
        public int LoggedIn { get; private set; } = 0;

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
        
        public void AddOneNewSession()
        {
            SessionCount++;
        }
        public void RemoveOneNewSession()
        {
            SessionCount--;
        }

        public void AddOneLoggedIn()
        {
            // TODO Bygg en lista av usernames som är inloggade här istället och kolla så de är unika
            // Löser buggen med felräkning vid cookie-auth mest troligt
            LoggedIn++;
        }

        public void RemoveOneLoggedIn()
        {
            LoggedIn--;
        }

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
