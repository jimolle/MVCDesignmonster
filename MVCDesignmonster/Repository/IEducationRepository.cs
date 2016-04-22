using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface IEducationRepository : IDisposable
    {
        void CreateEducation(Education education);

        IQueryable<Education> Search(Expression<Func<Education, bool>> predicate);
        // Följande två metoder underlättar lite så man slipper skriva predikatet själv
        IEnumerable<Education> GetPublicEducations();
        IEnumerable<Education> GetAllEducationsEvenPrivate();

        void UpdateEducation(Education education);
        void DeleteEducation(int educationId);
        void Save();
    }
}