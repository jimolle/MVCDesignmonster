using System;

namespace MVCDesignmonster.Logging
{
    public interface ILoggingService : IDisposable
    {
        void Log(LoggingViewModel loggingViewModel);
    }
}