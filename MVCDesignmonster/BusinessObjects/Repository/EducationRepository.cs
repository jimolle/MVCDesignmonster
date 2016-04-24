using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public class EducationRepository : RepoBase, IEducationRepository
    {

        public EducationRepository(ProfileDbContext context)
        {
            _context = context;
        }


        public void CreateEducation(Education education)
        {
            _context.Educations.Add(education);
        }

        public IQueryable<Education> Search(Expression<Func<Education, bool>> predicate)
        {
            return _context.Educations.Where(predicate);
        }

        public IEnumerable<Education> GetPublicEducations()
        {
            return Search(n => n.Public == true).ToList();
        }

        public IEnumerable<Education> GetAllEducationsEvenPrivate()
        {
            return _context.Educations.ToList();
        }

        public void UpdateEducation(Education education)
        {
            _context.Entry(education).State = EntityState.Modified;
        }

        public void DeleteEducation(int educationId)
        {
            var query = Search(n => n.EducationId == educationId).SingleOrDefault();

            _context.Educations.Remove(query);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}