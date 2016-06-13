using SetupIOCUnitTestingMock.Business.Interfaces;
using SetupIOCUnitTestingMock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetupIOCUnitTestingMock
{
    public class LogFilter : FilterAttribute, IActionFilter
    {
        public IAdviser Adviser { get; set; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var IsDFM = Adviser.IsDFM();

         //   throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
          //  throw new NotImplementedException();
        }
    }
}