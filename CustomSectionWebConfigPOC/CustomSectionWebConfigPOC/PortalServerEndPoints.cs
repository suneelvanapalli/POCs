using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomSectionWebConfigPOC
{

    public  class PortalServerEndPoints : ConfigurationSection
    {
        
        [ConfigurationProperty("endpoints", IsRequired = true , IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(PortalServerEndPointCollection) , AddItemName = "endpoint")]
        public PortalServerEndPointCollection endpoints
        {
            get
            {
                return (PortalServerEndPointCollection)this["endpoints"];
            }
            set
            {
                this["endpoints"] = value;

            }
        }
    }

    public class PortalServerEndPoint : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
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

        [ConfigurationProperty("value",  IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
            set
            {
                this["value"] = value;

            }
        }


    }
}