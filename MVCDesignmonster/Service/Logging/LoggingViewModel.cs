using System;

namespace MVCDesignmonster.Service.Logging
{
    public class LoggingViewModel
    {
        public string UserName { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string RawUrl { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}