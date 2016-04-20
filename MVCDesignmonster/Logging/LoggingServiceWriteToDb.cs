using System;
using System.IO;
using System.Web;
using MVCDesignmonster.Repository;

namespace MVCDesignmonster.Logging
{
    public class LoggingServiceWriteToDb : ILoggingService
    {
        // With EducationRepository
        private ILogRepository _repo;

        public LoggingServiceWriteToDb()
        {
            _repo = new LogRepository(new RepoDbContext());
        }

        public LoggingServiceWriteToDb(ILogRepository educationRepo)
        {
            _repo = educationRepo;
        }

        public void Log(LoggingViewModel loggingViewModel)
        {
            _repo.Log(loggingViewModel);
        }
    }
}