using System;

namespace MVCDesignmonster.Service.SessionStats
{
    public class TrackedUser
    {
        public string SessionId { get; set; }
        public string UserName { get; set; }
        public DateTime TimeStampLastActive { get; set; }
    }
}