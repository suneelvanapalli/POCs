using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SetupIOCUnitTestingMock.Configuration
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
}