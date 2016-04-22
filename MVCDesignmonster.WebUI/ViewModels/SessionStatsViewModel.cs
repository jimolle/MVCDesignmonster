using System.Collections.Generic;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.WebUI.ViewModels
{
    public class SessionStatsViewModel
    {
        //public List<string> TrackedUsers { get; set; }
        public string SessionStats { get; set; }

        public List<StatLog> StatLogs { get; set; }
    }
}