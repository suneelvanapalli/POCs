using SetupIOCUnitTestingMock.Business.Interfaces;
using SetupIOCUnitTestingMock.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetupIOCUnitTestingMock.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdviser _adviser;
        private readonly IConfigurationManager _configManager;
        
        public HomeController(IAdviser adviser, IConfigurationManager configManager)
        {
            _adviser = adviser;
            _configManager = configManager;
        }

        [LogFilter]
        public ActionResult Index()
        {
            var _isDFN = _adviser.IsDFM();
            ViewBag.IsDFM = _isDFN;
            return View();
        }

        public ActionResult About()
        {
            var route = _configManager.GetPortalServerEndPoint("getuserdetails");

            ViewBag.Route = route;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}