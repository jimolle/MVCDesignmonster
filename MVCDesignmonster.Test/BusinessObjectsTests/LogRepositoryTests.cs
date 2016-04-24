using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Service.Logging;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class LogRepositoryTests
    {
        private ILogRepository _repo;

        public LogRepositoryTests()
        {
            _repo = new LogRepository(new ProfileDbContext());
            //_repo = new FakeLogPageRepository();
        }


        [TestMethod]
        public void Log()
        {
            // Arrange

            // Act
            var loggingVM = new LoggingViewModel()
            {
                Action = null,
                Controller = null,
                RawUrl = "Fake/Fake/Url",
                UserName = "FakeName",
                TimeStamp = DateTime.Now
            };
            _repo.Log(loggingVM);

            var expected = loggingVM.RawUrl;

            // Assert
            Assert.AreEqual(expected, _repo.GetLast100LogPosts().FirstOrDefault(n => n.Url == "Fake/Fake/Url").Url);
        }

        [TestMethod]
        public void GetLast100Logs()
        {
            // Arrange
            var loggingVM = new LoggingViewModel()
            {
                Action = null,
                Controller = null,
                RawUrl = "Fake/Fake/Url2",
                UserName = "FakeName2",
                TimeStamp = DateTime.Now
            };
            _repo.Log(loggingVM);

            // Act

            // Assert
            Assert.IsTrue(_repo.GetLast100LogPosts().Count() > 0);
        }

    }
}
