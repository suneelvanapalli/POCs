using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoFactory = new AutoFactory();
            IAuto car = autoFactory.CreateInstance("Audi");
            car.On();
            car.Off();

            Console.ReadKey();
        }
    }
}
