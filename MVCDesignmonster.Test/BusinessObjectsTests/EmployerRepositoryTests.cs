using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class EmployerRepositoryTests
    {
        private IEmployerRepository _repo;

        public EmployerRepositoryTests()
        {
            //_repo = new EmployerRepository(new ProfileDbContext());
            _repo = new FakeEmployerRepository();
        }


        [TestMethod]
        public void GetPublicEmployers()
        {
            // Arrange
            var educ = _repo.GetPublicEmployers();

            // Act
            int count = 1;

            // Assert
            Assert.AreEqual(count, educ.Count());
        }

        [TestMethod]
        public void UpdateEmployer()
        {
            // Arrange
            var emp = _repo.GetAllEmployersEvenPrivate().SingleOrDefault(n => n.EmployerId == 2);


            // Act
            emp.Name = "UPDATED";
            emp.StartDate = DateTime.Parse("3000-01-01");
            emp.EndDate = DateTime.Parse("3001-01-01");
            emp.Public = false;

            _repo.UpdateEmployer(emp);
            _repo.Save();


            // Assert
            Assert.AreEqual(emp.Name, _repo.GetAllEmployersEvenPrivate().SingleOrDefault(n => n.EmployerId == 2).Name);
        }

        [TestMethod]
        public void CreateEmployer()
        {
            // Arrange

            // Act
            var emp = new Employer()
            {
                Name = "NewEmployer",
                StartDate = DateTime.Parse("2013-01-01"),
                EndDate = DateTime.Parse("2013-06-01"),
                Public = true
            };

            _repo.CreateEmployer(emp);
            _repo.Save();

            // Assert
            Assert.AreEqual(emp.Name, _repo.GetAllEmployersEvenPrivate().SingleOrDefault(n => n.Name == "NewEmployer").Name);
        }

        [TestMethod]
        public void DeleteEmployer()
        {
            // Arrange

            // Act
            _repo.DeleteEmployer(1);
            _repo.Save();

            // Assert
            Assert.IsNull(_repo.GetAllEmployersEvenPrivate().SingleOrDefault(n => n.EmployerId == 1));
        }

    }
}