using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.Service.SessionStats;

namespace MVCDesignmonster.Test.ServiceTests
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
