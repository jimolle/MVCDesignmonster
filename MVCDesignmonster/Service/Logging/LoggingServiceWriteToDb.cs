using System;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Service.Logging
{
    public class LoggingServiceWriteToDb : ILoggingService
    {
        // With EducationRepository
        private ILogRepository _repo;

        public LoggingServiceWriteToDb()
        {
            _repo = new LogRepository();
        }

        public LoggingServiceWriteToDb(ILogRepository educationRepo)
        {
            _repo = educationRepo;
        }

        public void Log(LoggingViewModel loggingViewModel)
        {
            _repo.Log(loggingViewModel);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repo.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}