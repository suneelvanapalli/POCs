using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomSectionWebConfigPOC
{
    [ConfigurationCollection(typeof(EventsDispatchConfigurationElement))]
    public class GenericConfigurationElementCollection : ConfigurationElementCollection
    {
        
        public EventsDispatchConfigurationElement this[int index]
        {
            get { return (EventsDispatchConfigurationElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
               

        protected override ConfigurationElement CreateNewElement()
        {
            return new EventsDispatchConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EventsDispatchConfigurationElement)element).Name;
        }

       
        
    }

    public class DispatcherConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("maxRetry", IsRequired = false, DefaultValue = 5)]
        public int MaxRetry
        {
            get
            {
                return (int)this["maxRetry"];
            }
            set
            {
                this["maxRetry"] = value;
            }
        }

        [ConfigurationProperty("eventsDispatches", IsRequired = true)]
        [ConfigurationCollection(typeof(EventsDispatchConfigurationElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public GenericConfigurationElementCollection EventsDispatches
        {
            get { return (GenericConfigurationElementCollection)this["eventsDispatches"]; }
        }
    }

    public class EventsDispatchConfigurationElement : ConfigurationElement
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
    }







}