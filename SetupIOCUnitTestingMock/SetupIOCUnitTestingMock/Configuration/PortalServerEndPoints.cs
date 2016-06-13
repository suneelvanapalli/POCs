using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SetupIOCUnitTestingMock.Configuration
{  

    public class PortalServerEndPoints : ConfigurationSection
    {

        [ConfigurationProperty("endpoints", IsRequired = true)]
        [ConfigurationCollection(typeof(EndPoint), AddItemName = "endpoint")]
        public EndPointCollection EndPoints
        {
            get { return (EndPointCollection)this["endpoints"]; }
        }
    }

   
}