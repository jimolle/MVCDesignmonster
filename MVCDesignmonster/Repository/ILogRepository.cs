using System;
using System.Collections.Generic;
using MVCDesignmonster.Logging;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface ILogRepository : IDisposable
    {
        void Log(LoggingViewModel loggingvm);
        IEnumerable<StatLog> GetLast100LogPosts();
    }
}