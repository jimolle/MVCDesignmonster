using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDesignmonster.Singleton
{
    public class SessionStats
    {
        private static readonly SessionStats _instance;

        static SessionStats()
        {
            _instance = new SessionStats();
            // Static constructor only gets called once.
            // + No need for locks in Instance-property!?
        }

        public static SessionStats Instance
        {
            get
            {
                //if (_instance == null)
                //    _instance = new SessionStats();
                return _instance;
            }
        }


        public int DoSomeStats(int num1)
        {
            return num1;
        }

    }
}
