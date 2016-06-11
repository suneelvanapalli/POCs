using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomSectionWebConfigPOC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //To retrieve from custom config section-----------------------------------
            var config = (PortalServerEndPoints) 
                          ConfigurationManager.GetSection("PortalServerEndPoints");

           var elem= config.EndPoints.GetElement("getuserdetails");
            return View();
        }
    }
}