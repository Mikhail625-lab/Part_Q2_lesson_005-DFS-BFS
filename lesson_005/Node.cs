using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Node
    {
        public Node Left;
        public Node Right;
        public int Value;
        public int data;
        public bool IsLeaf;
        public bool Visit;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node()
        { Data = 0; }
        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Data = v;
            IsLeaf = false;
            Visit = false;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\t\tData[{0}]      Value:[{1}]      " +
                "Left:[{2}]      Right:[{3}]",
                this.data, this.Value, this.Left, this.Right);
        }
        public void DisplayNode(Node nd1)
        {
            Console.WriteLine("\t\tLeft:[{0}]      Right:[{1}]", nd1.Left, nd1.Right);
        }
    }  //  end_of_class Node
}
