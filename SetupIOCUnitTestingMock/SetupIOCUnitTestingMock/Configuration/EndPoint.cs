using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SetupIOCUnitTestingMock.Configuration
{
    public class EndPoint : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("route", IsRequired = true)]
        public string Route
        {
            get
            {
                return (string)this["route"];
            }
            set
            {
                this["route"] = value;
            }
        }
    }
}