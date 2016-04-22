using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class StartPageRepositoryTests
    {
        private IStartpageRepository _repo;

        public StartPageRepositoryTests()
        {
            //_repo = new StartPageRepository(new ProfileDbContext());
            _repo = new FakeStartPageRepository();
        }

        //public StartPageRepositoryTests(IStartpageRepository startpageRepository)
        //{
        //    _repo = startpageRepository;
        //}

        [TestMethod]
        public void GetStartpage()
        {
            // Arrange

            // Act
            Startpage item = _repo.GetStartpage();


            // Assert
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Update()
        {
            // Arrange
            var startpage = _repo.GetStartpage();

            // Act
            var updated = "UPDATED";
            startpage.WelcomeTitle = "UPDATED";
            _repo.Save();


            // Assert
            Assert.AreEqual(updated, _repo.GetStartpage().WelcomeTitle);
        }

    }
}
