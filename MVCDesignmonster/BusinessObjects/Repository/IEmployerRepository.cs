using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface IEmployerRepository : IDisposable
    {
        void CreateEmployer(Employer employer);

        // 2 alt att göra detta.
        IQueryable<Employer> Search(Expression<Func<Employer, bool>> predicate);
        IEnumerable<Employer> GetPublicEmployers();
        IEnumerable<Employer> GetAllEmployersEvenPrivate();

        void UpdateEmployer(Employer employer);
        void DeleteEmployer(int employerId);
        void Save();
    }
}