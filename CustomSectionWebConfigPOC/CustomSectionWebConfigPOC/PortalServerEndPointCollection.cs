using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CustomSectionWebConfigPOC
{
    [ConfigurationCollection(typeof(PortalServerEndPoint), AddItemName = "endpoint")]
    public class PortalServerEndPointCollection : ConfigurationElementCollection 
    {
       

        protected override ConfigurationElement CreateNewElement()
        {
            return new PortalServerEndPoint();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PortalServerEndPoint)element).Name;
        }

        public void Add(PortalServerEndPoint endPoint)
        {            
            BaseAdd(endPoint);
        }

    }
}