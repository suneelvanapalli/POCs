using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetstandardconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
           // var coreobj = new dotnetcorecls();
            //coreobj.test();

            var framwrkobj = new dotnetframeworklib.dotnetframeworklibcls();

            var standobj = new dotnetstandardlib.dotnetstandardcls();

            Console.WriteLine("Hello World!");
        }
    }
}
