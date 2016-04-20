using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private RepoDbContext _context;

        public ProfileRepository(RepoDbContext context)
        {
            this._context = context;
        }

        public Profile GetProfile()
        {
            return _context.Profile.SingleOrDefault();
        }

        public void UpdateProfile(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
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
