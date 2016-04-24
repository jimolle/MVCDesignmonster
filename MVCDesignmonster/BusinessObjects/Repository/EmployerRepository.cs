using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class EmployerRepository : RepoBase, IEmployerRepository
    {

        public EmployerRepository(ProfileDbContext context)
        {
            _context = context;
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

    }
}
