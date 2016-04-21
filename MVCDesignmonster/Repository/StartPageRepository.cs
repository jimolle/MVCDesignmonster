using System;
using System.Data.Entity;
using System.Linq;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class StartPageRepository : IStartpageRepository
    {
        private ProfileDbContext _context;
        public StartPageRepository()
        {
            _context = new ProfileDbContext();
        }
        public StartPageRepository(ProfileDbContext context)
        {
            this._context = context;
        }


        public Startpage GetStartpage()
        {
            return _context.Startpage.First();
        }

        public void UpdateStartpage(Startpage startpage)
        {
            _context.Entry(startpage).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
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