using System.Collections.Generic;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Service.Logging;

namespace MVCDesignmonster.Test.Fakes
{
    public class FakeLogPageRepository : ILogRepository
    {
        private List<StatLog> _context = new List<StatLog>();

        public FakeLogPageRepository()
        {
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
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
            _context.Add(loggingRow);
        }

        public IEnumerable<StatLog> GetLast100LogPosts()
        {
            return _context.ToList();
        }

        public void Save()
        {
            // do nothing
        }
    }
}