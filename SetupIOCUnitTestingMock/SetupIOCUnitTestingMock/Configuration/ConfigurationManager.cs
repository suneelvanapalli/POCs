using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConfigurationManager =  System.Configuration.ConfigurationManager;

namespace SetupIOCUnitTestingMock.Configuration
{
    public class WebConfigurationManager : IConfigurationManager
    {
        public string GetPortalServerEndPoint(string name)
        {
            var config = (PortalServerEndPoints) ConfigurationManager.GetSection("PortalServerEndPoints");

            var elem = config.EndPoints.GetElement("getuserdetails");

            return elem.Route;
        }
    }
}