using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeBasedModellingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthWindDBContext())
            {
                var data = db.Categories;

                foreach(var c in data)
                {
                    Console.WriteLine(c.CategoryName);
                }
            }

            Console.ReadKey();
        }
    }
}
