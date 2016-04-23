using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface IEducationRepository : IDisposable
    {
        void CreateEducation(Education education);

        IQueryable<Education> Search(Expression<Func<Education, bool>> predicate);
        IEnumerable<Education> GetPublicEducations();
        IEnumerable<Education> GetAllEducationsEvenPrivate();

        void UpdateEducation(Education education);
        void DeleteEducation(int educationId);
        void Save();
    }
}