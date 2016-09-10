using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree b = new BinaryTree();

            b.insert(4);
            b.insert(2);
            b.insert(5);
            b.insert(5);
            b.insert(6);
            b.insert(1);
            b.insert(4);

            //  b.display();

            b.Print(b.root);
            Console.ReadLine();
        }
    }
}
