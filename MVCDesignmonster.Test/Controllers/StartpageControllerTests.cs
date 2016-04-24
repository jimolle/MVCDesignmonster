using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.Test.Fakes;
using MVCDesignmonster.WebUI.Controllers;

namespace MVCDesignmonster.Test.Controllers
{
    [TestClass]
    public class StartpageControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController(new FakeStartPageRepository());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
