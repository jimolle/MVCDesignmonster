using System;
using System.Collections.Generic;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.Service.Logging;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface ILogRepository : IDisposable
    {
        void Log(LoggingViewModel loggingvm);
        IEnumerable<StatLog> GetLast100LogPosts();
    }
}