using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class BMW : IAuto
    {
        public void Off()
        {
            Console.WriteLine("Car {0} is started", this.GetType().Name);
        }

        public void On()
        {
            Console.WriteLine("Car {0} is stopped", this.GetType().Name);
        }
    }
}
