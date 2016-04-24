using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProfileDbContext _context = new ProfileDbContext();
        private IProfileRepository _profileRepo;
        private IEducationRepository _educationRepo;
        private IEmployerRepository _employerRepo;

        private IStartpageRepository _startpageRepo;
        private ILogRepository _logRepo;

        public UnitOfWork()
        { }


        public IProfileRepository ProfileRepository
        {
            get
            {
                if (_profileRepo == null)
                    _profileRepo = new ProfileRepository(_context);
                return _profileRepo;
            }
        }

        public IEducationRepository EducationRepository
        {
            get
            {
                if (_educationRepo == null)
                    _educationRepo = new EducationRepository(_context);
                return _educationRepo;
            }
        }

        public IEmployerRepository EmployerRepository
        {
            get
            {
                if (_employerRepo == null)
                    _employerRepo = new EmployerRepository(_context);
                return _employerRepo;
            }
        }

        public IStartpageRepository StartpageRepository
        {
            get
            {
                if (_startpageRepo == null)
                    _startpageRepo = new StartPageRepository(_context);
                return _startpageRepo;;
            }
        }

        public ILogRepository LogRepository
        {
            get
            {
                if (_logRepo == null)
                    _logRepo = new LogRepository(_context);
                return _logRepo;
            }
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
