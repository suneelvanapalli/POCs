using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class AutoFactory
    {
        private  Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadAutoInstances();
        }

        public IAuto CreateInstance(string name)
        {
            var type = GetInstance(name);

            return Activator.CreateInstance(type) as IAuto;
        }

        private Type GetInstance(string name)
        {
            return autos[name];
        }

        private void LoadAutoInstances()
        {
            autos = new Dictionary<string, Type>();
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach(var type in types)
            {
                if(type.GetInterface(typeof(IAuto).ToString())!= null)
                {
                    autos[type.Name] = type;
                }
            }
        }
    }
}
