using System;

namespace GB_Q2_lesson005
{
   public class Node
    {

        public Node Left;
        public Node Right;
        public int Value;
        public int data;
        public bool IsLeaf;
        public bool Visit;
        public int Data
 
        public Node() // <-- constructor
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
