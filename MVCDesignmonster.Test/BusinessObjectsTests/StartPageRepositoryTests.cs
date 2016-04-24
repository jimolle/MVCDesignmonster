using System;
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
        public void UpdateStartpage()
        {
            // Arrange
            var startpage = _repo.GetStartpage();

            // Act
            startpage.StartpageId = 1;
            startpage.WelcomeTitle = "Test Testtitel";
            startpage.WelcomeText =
                "[WelcomeText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor.";

            _repo.UpdateStartpage(startpage);
            _repo.Save();


            // Assert
            Assert.AreEqual(startpage.WelcomeTitle, _repo.GetStartpage().WelcomeTitle);
        }

    }
    
}
