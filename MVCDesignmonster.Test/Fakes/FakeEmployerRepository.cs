using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Test.Fakes
{
    public class FakeEmployerRepository : IEmployerRepository
    {
        private List<Employer> _context = new List<Employer>();

        public FakeEmployerRepository()
        {
            var employers = new List<Employer>
            {
                new Employer()
                {
                    EmployerId = 1,
                    Name = "Bofors AB",
                    StartDate = DateTime.Parse("2013-01-01"),
                    EndDate = DateTime.Parse("2013-06-01"),
                    Public = true
                },
                new Employer()
                {
                    EmployerId = 2,
                    Name = "Rädda Barnen",
                    StartDate = DateTime.Parse("2014-06-01"),
                    EndDate = DateTime.Parse("2014-08-31"),
                    Public = false
                }
            };
            foreach (var employer in employers)
                _context.Add(employer);
        }

        public void CreateEmployer(Employer employer)
        {
            _context.Add(employer);
        }

        public IQueryable<Employer> Search(Expression<Func<Employer, bool>> predicate)
        {
            return _context.AsQueryable().Where(predicate);
        }

        public IEnumerable<Employer> GetPublicEmployers()
        {
            return Search(n => n.Public == true).ToList();
        }

        public IEnumerable<Employer> GetAllEmployersEvenPrivate()
        {
            return _context.ToList();
        }

        public void UpdateEmployer(Employer employer)
        {
            var educ = GetAllEmployersEvenPrivate().FirstOrDefault(n => n.EmployerId == employer.EmployerId);

            educ.EmployerId = employer.EmployerId;
            educ.Name = employer.Name;
            educ.StartDate = employer.StartDate;
            educ.EndDate = employer.EndDate;
            educ.Public = employer.Public;
        }

        public void DeleteEmployer(int employerId)
        {
            var educ = GetAllEmployersEvenPrivate().FirstOrDefault(n => n.EmployerId == employerId);

            _context.Remove(educ);
        }


        public void Save()
        {
            // do nothing
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}