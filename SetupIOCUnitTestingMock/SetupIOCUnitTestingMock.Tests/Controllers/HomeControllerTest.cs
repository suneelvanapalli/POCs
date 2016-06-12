using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetupIOCUnitTestingMock;
using SetupIOCUnitTestingMock.Controllers;
using NSubstitute;

namespace SetupIOCUnitTestingMock.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var _adviserService = Substitute.For<IAdviser>();
            _adviserService.IsDFM().Returns(false);
            // Arrange
            HomeController controller = new HomeController(_adviserService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewBag.IsDFM, true);
        }

       
    }
}
