using System;
using System.Data.Entity;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private ProfileDbContext _context;

        public ProfileRepository(ProfileDbContext context)
        {
            this._context = context;
        }

        public Profile GetProfile()
        {
            return _context.Profile.FirstOrDefault();
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
