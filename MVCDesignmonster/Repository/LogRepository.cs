using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCDesignmonster.Logging;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class LogRepository : ILogRepository
    {
        private RepoDbContext _context;

        public LogRepository(RepoDbContext context)
        {
            this._context = context;
        }


        public void CreateEducation(Education education)
        {
            _context.Educations.Add(education);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Log(LoggingViewModel loggingvm)
        {
            var loggingRow = new StatLog()
            {
                TimeStamp = loggingvm.TimeStamp,
                UserName = loggingvm.UserName,
                Url = loggingvm.Controller + "/" + loggingvm.Action
            };
            _context.StatLogs.Add(loggingRow);
            _context.SaveChanges();
        }

        public IEnumerable<StatLog> GetLast100LogPosts()
        {
            // TODO Ändra till 100
            return _context.StatLogs.Take(5);
        }
    }
}