using System;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public abstract class RepoBase : IDisposable
    {
        protected ProfileDbContext _context;

        //protected ProfileDbContext DataContext
        //{
        //    get
        //    {
        //        {
        //            if (_dataContext == null)
        //                _dataContext = new ProfileDbContext();
        //        }
        //        return _dataContext;
        //    }
        //}


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}