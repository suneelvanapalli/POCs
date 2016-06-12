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
        
        public HomeController(IAdviser adviser)
        {
            _adviser = adviser;
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