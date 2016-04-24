using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Test.Fakes
{
    public class FakeEducationRepository : IEducationRepository
    {
        private List<Education> _context = new List<Education>();

        public FakeEducationRepository()
        {
            var educations = new List<Education>
            {
                new Education()
                {
                    EducationId = 1,
                    Name = "DirtShoweling101",
                    Description = "A good education about showeling dirt. A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt. ",
                    SchoolName = "FiveGardens",
                    StartDate = DateTime.Parse("2010-01-01"),
                    EndDate = DateTime.Parse("2011-01-01"),
                    Public = true
                },
                new Education()
                {
                    EducationId = 2,
                    Name = "Databases101",
                    Description = "A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. ",
                    SchoolName = "SchoolOfDatabases",
                    StartDate = DateTime.Parse("2012-01-01"),
                    EndDate = DateTime.Parse("2013-01-01"),
                    Public = false
                }
            };
            foreach (var education in educations)
                _context.Add(education);
        }

        public void CreateEducation(Education education)
        {
            _context.Add(education);
        }

        public IQueryable<Education> Search(Expression<Func<Education, bool>> predicate)
        {
            return _context.AsQueryable().Where(predicate);
        }

        public IEnumerable<Education> GetPublicEducations()
        {
            return Search(n => n.Public == true).ToList();
        }

        public IEnumerable<Education> GetAllEducationsEvenPrivate()
        {
            return _context.ToList();
        }

        public void UpdateEducation(Education education)
        {
            var educ = GetAllEducationsEvenPrivate().FirstOrDefault(n => n.EducationId == education.EducationId);

            educ.EducationId = education.EducationId;
            educ.Name = education.Name;
            educ.Description = education.Description;
            educ.SchoolName = education.SchoolName;
            educ.StartDate = education.StartDate;
            educ.EndDate = education.EndDate;
            educ.Public = education.Public;
        }

        public void DeleteEducation(int educationId)
        {
            var educ = GetAllEducationsEvenPrivate().FirstOrDefault(n => n.EducationId == educationId);

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