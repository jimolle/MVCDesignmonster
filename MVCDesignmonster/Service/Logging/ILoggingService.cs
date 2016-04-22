using System;

namespace MVCDesignmonster.Service.Logging
{
    public interface ILoggingService : IDisposable
    {
        void Log(LoggingViewModel loggingViewModel);
    }
}