using System;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Service.Logging
{
    public class LoggingServiceWriteToDb : ILoggingService
    {
        // With EducationRepository
        private IUnitOfWork _unitOfWork;

        public LoggingServiceWriteToDb()
        {
            _unitOfWork = new UnitOfWork();
        }

        public LoggingServiceWriteToDb(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Log(LoggingViewModel loggingViewModel)
        {
            _unitOfWork.LogRepository.Log(loggingViewModel);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
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