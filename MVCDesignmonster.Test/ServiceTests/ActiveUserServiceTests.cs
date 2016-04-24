using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Service.SessionStats;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class ActiveUserServiceTests
    {

        [TestMethod]
        public void ActiveUserServiceShouldOnlyInstansiateOneInstance()
        {
            // Arrange

            // Act
            var aus = ActiveUserService.Instance;
            var aus2 = ActiveUserService.Instance;


            // Assert
            Assert.AreSame(aus, aus2);
        }

    }
}
