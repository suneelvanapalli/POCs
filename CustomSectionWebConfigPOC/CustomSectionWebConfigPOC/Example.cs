using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomSectionWebConfigPOC
{
    [ConfigurationCollection(typeof(EndPoint))]
    public class EndPointCollection : ConfigurationElementCollection
    {
        
        public EndPoint this[int index]
        {
            get { return (EndPoint)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

       public EndPoint GetElement(string name)
        {
            return (EndPoint)this.BaseGet(name);
            
        }

        


        protected override ConfigurationElement CreateNewElement()
        {
            return new EndPoint();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EndPoint)element).Name;
        }

       
        
    }

    public class PortalServerEndPoints : ConfigurationSection
    {      

        [ConfigurationProperty("endpoints", IsRequired = true)]
        [ConfigurationCollection(typeof(EndPoint), AddItemName = "endpoint")]
        public EndPointCollection EndPoints
        {
            get { return (EndPointCollection)this["endpoints"]; }
        }
    }

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