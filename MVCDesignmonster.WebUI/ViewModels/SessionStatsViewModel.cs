using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.WebUI.ViewModels
{
    public class SessionStatsViewModel
    {
        //public List<string> LoggedInUsers { get; set; }
        public int TotalSessions { get; set; }
        public int LoggedInSessions { get; set; }

        public List<StatLog> StatLogs { get; set; }
    }
}