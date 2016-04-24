using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class EducationRepositoryTests
    {
        private IEducationRepository _repo;

        public EducationRepositoryTests()
        {
            _repo = new EducationRepository(new ProfileDbContext());
            //_repo = new FakeEducationRepository();
        }


        [TestMethod]
        public void GetPublicEducations()
        {
            // Arrange
            var educ = _repo.GetPublicEducations();

            // Act
            int count = 1;

            // Assert
            Assert.AreEqual(count, educ.Count());
        }

        [TestMethod]
        public void UpdateEducation()
        {
            // Arrange
            var educ = _repo.GetAllEducationsEvenPrivate().SingleOrDefault(n => n.EducationId == 2);


            // Act
            educ.Name = "UPDATED";
            educ.Description =
                "UPDATED A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. ";
            educ.SchoolName = "UPDATED SchoolOfDatabases";
            educ.StartDate = DateTime.Parse("3000-01-01");
            educ.EndDate = DateTime.Parse("3001-01-01");
            educ.Public = false;

            _repo.UpdateEducation(educ);
            _repo.Save();


            // Assert
            Assert.AreEqual(educ.SchoolName, _repo.GetAllEducationsEvenPrivate().SingleOrDefault(n => n.EducationId == 2).SchoolName);
        }

        [TestMethod]
        public void CreateEducation()
        {
            // Arrange

            // Act
            var newEduc = new Education()
            {
                Name = "NewEducation",
                Description =
                    "A good education about showeling dirt. A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt.  A good education about showeling dirt. ",
                SchoolName = "FiveGardens",
                StartDate = DateTime.Parse("2010-01-01"),
                EndDate = DateTime.Parse("2011-01-01"),
                Public = true
            };

            _repo.CreateEducation(newEduc);
            _repo.Save();


            var debug = _repo.GetAllEducationsEvenPrivate().Where(n => n.Name == "NewEducation");

            // Assert
            Assert.AreEqual(newEduc.Name, _repo.GetAllEducationsEvenPrivate().SingleOrDefault(n => n.Name == "NewEducation").Name);
        }

        [TestMethod]
        public void DeleteEducation()
        {
            // Arrange

            // Act
            _repo.DeleteEducation(1);
            _repo.Save();

            // Assert
            Assert.IsNull(_repo.GetAllEducationsEvenPrivate().FirstOrDefault(n => n.EducationId == 1));
        }

    }
}