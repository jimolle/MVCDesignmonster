using System;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface IEmployerRepository : IDisposable
    {
        void CreateEmployer(Employer employer);

        // 2 alt att göra detta.
        IQueryable<Employer> Search(Expression<Func<Employer, bool>> predicate);
        void GetPublicEmployers();
        void GetAllEmployers();

        void UpdateEducation(Education education);
        void DeleteEducation(Education education);
        void Save();
    }
}