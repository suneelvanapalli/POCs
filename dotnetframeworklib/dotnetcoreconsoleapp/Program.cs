using dotnetcorelib;
using System;

namespace dotnetcoreconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreobj = new dotnetcorecls();
            coreobj.test();

            var framwrkobj = new dotnetframeworklib.dotnetframeworklibcls();

            var standobj = new dotnetstandardlib.dotnetstandardcls();

            Console.WriteLine("Hello World!");
        }
    }
}