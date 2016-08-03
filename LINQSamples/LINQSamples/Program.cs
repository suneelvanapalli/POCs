using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
    class Program
    {

     static   IEnumerable<Adviser> advisers = new List<Adviser>()
            {
                new Adviser() { AdviserID="1", FirstName = "Suneel", LastName="Vanapalli" },
                new Adviser() { AdviserID="2", FirstName = "Michael", LastName="Pullen" },
                new Adviser() { AdviserID="3", FirstName = "Ben", LastName="Twining" }
            };

        static void Main(string[] args)
        {
            Helper.InvokeAllStaticMethods(typeof(Program));
            Console.ReadKey();
        }


        public static void BasicLINQQuery()
        {
            Helper.LogMethodName();
            string[] names = { "Aaron", "Finch", "Steve", "Smith" };

            var sortednames = from s in names
                              where s.StartsWith("s", true, null)
                              orderby s ascending
                              select s;

            Helper.Dump<string>(sortednames);

        }

        public static void LinQQueryOfObjecsts()
        {

            Helper.Dump<Adviser>(advisers);
            Console.WriteLine(advisers.MyCount());
        }

        public static void CustomFilter()
        {
            var query  = advisers.Filter(m => m.FirstName.Length > 3);
            
            foreach(var a in query)
            {
                Console.WriteLine(a.LastName);
            }
        }

        private bool NameStartsWith(Adviser adv)
        {
            return adv.FirstName.StartsWith("s", StringComparison.OrdinalIgnoreCase);
        }




    }
}
