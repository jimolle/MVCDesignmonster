using System;
using System.Collections.Generic;
using System.Linq;
using MVCDesignmonster.Logging;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class LogRepository : ILogRepository
    {
        private ProfileDbContext _context;

        public LogRepository(ProfileDbContext context)
        {
            this._context = context;
        }

        public void Log(LoggingViewModel loggingvm)
        {
            var loggingRow = new StatLog()
            {
                TimeStamp = loggingvm.TimeStamp,
                UserName = loggingvm.UserName,
                //Url = "/" + loggingvm.Controller + "/" + loggingvm.Action
                Url = loggingvm.RawUrl
            };
            _context.StatLogs.Add(loggingRow);
            _context.SaveChanges();
        }

        public IEnumerable<StatLog> GetLast100LogPosts()
        {
            return _context.StatLogs.OrderByDescending(n => n.TimeStamp).Take(100);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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