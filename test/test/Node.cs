using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Node
    {
        public int number;
        public Node rightLeaf;
        public Node leftLeaf;
        public int repeatedCount;

        public Node(int value)
        {
            number = value;
            repeatedCount = 0;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool isLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void insertData(ref Node node, int data)
        {

            if (node == null)
            {
                node = new Node(data);
            }
            else if (node.number < data)
            {
                insertData(ref node.rightLeaf, data);
            }

            else if (node.number > data)
            {
                insertData(ref node.leftLeaf, data);
            }

            else if(node.number == data)
            {
                node.repeatedCount++;
            }
        }

        public bool search(Node node, int s)
        {
            if (node == null)
                return false;

            if (node.number == s)
            {
                return true;
            }
            else if (node.number < s)
            {
                return search(node.rightLeaf, s);
            }
            else if (node.number > s)
            {
                return search(node.leftLeaf, s);
            }

            return false;
        }


        public void display(Node n)
        {
            if (n == null)
                return;

            display(n.leftLeaf);
            Console.Write(" " + n.number + ":" + n.repeatedCount);
            display(n.rightLeaf);
        }

    }
}
