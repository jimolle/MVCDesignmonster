using System;
using System.Collections.Generic;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.Service.Logging;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class LogRepository : RepoBase, ILogRepository
    {
        //private ProfileDbContext _context;

        //public LogRepository(ProfileDbContext context)
        //{
        //    this._context = context;
        //}

        public void Log(LoggingViewModel loggingvm)
        {
            var loggingRow = new StatLog()
            {
                TimeStamp = loggingvm.TimeStamp,
                UserName = loggingvm.UserName,
                //Url = "/" + loggingvm.Controller + "/" + loggingvm.Action
                Url = loggingvm.RawUrl
            };
            DataContext.StatLogs.Add(loggingRow);
            DataContext.SaveChanges();
        }

        public IEnumerable<StatLog> GetLast100LogPosts()
        {
            return DataContext.StatLogs.OrderByDescending(n => n.TimeStamp).Take(100);
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            DataContext.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}