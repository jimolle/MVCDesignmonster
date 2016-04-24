using System;
using System.Data.Entity;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class StartPageRepository : RepoBase, IStartpageRepository
    {
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

    }
}