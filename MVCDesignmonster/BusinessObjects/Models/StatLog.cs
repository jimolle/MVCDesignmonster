using System;

namespace MVCDesignmonster.BusinessObjects.Models
{
    public class StatLog
    {
        public int StatLogId { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}