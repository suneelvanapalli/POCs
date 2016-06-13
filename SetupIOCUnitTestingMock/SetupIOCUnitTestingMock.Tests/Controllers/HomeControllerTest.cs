using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetupIOCUnitTestingMock;
using SetupIOCUnitTestingMock.Controllers;
using NSubstitute;
using SetupIOCUnitTestingMock.Business.Interfaces;
using SetupIOCUnitTestingMock.Configuration;

namespace SetupIOCUnitTestingMock.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var _adviserService = Substitute.For<IAdviser>();
            _adviserService.IsDFM().Returns(true);
            // Arrange
            HomeController controller = new HomeController(_adviserService, null);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewBag.IsDFM, true);
        }
              

        [TestMethod]        
        public void About()
        {
            var _configManager = Substitute.For<IConfigurationManager>();
            var route = "user/getdetails";

            //Mock
            _configManager.GetPortalServerEndPoint("getuserdetails").Returns(route);

            // Arrange
            HomeController controller = new HomeController(null, _configManager);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewBag.Route, route);
        }


    }
}
