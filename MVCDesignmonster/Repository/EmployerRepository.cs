using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private RepoDbContext _context;
        public EmployerRepository()
        {
            _context = new RepoDbContext();
        }
        public EmployerRepository(RepoDbContext context)
        {
            this._context = context;
        }


        public void CreateEmployer(Employer employer)
        {
            _context.Employers.Add(employer);
        }

        public IQueryable<Employer> Search(Expression<Func<Employer, bool>> predicate)
        {
            return _context.Employers.Where(predicate);
        }

        public IEnumerable<Employer> GetPublicEmployers()
        {
            return Search(n => n.Public == true).ToList();
        }

        public IEnumerable<Employer> GetAllEmployersEvenPrivate()
        {
            return _context.Employers.ToList();
        }

        public void UpdateEmployer(Employer employer)
        {
            _context.Entry(employer).State = EntityState.Modified;
        }

        public void DeleteEmployer(int employerId)
        {
            var query = Search(n => n.EmployerId == employerId).SingleOrDefault();

            _context.Employers.Remove(query);
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
