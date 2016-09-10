using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class BinaryTree
    {
        public Node root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty()
        {
            return root == null;
        }

        public void insert(int d)
        {
            if (isEmpty())
            {
                root = new Node(d);
            }
            else
            {
                root.insertData(ref root, d);
            }

            count++;
        }

        public bool search(int s)
        {
            return root.search(root, s);
        }

        public bool isLeaf()
        {
            if (!isEmpty())
                return root.isLeaf(ref root);

            return true;
        }

        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }

        public int Count()
        {
            return count;
        }

        public string output;
        public void Print(params Node[] nodes)
        {
            if (nodes == null)
            {
                output += root.number + ":" + root.repeatedCount;
                output += ",";
                return;
            }

            List<Node> childnodes = new List<Node>();

            foreach (var node in nodes)
            {
                if (node.leftLeaf == null)
                {
                    output += ",";
                }
                else
                {
                    output += node.leftLeaf.number + ":" + node.repeatedCount;
                    output += ",";
                    childnodes.Add(node.leftLeaf);
                }

                if (node.rightLeaf == null)
                {
                    output += ",";
                }
                else
                {
                    output += node.rightLeaf.number + ":" + node.repeatedCount;
                    output += ",";
                    childnodes.Add(node.rightLeaf);
                }
                
            }

            if (childnodes.Count() == 0) return;
            Print(childnodes.ToArray());
        }


    }
}
