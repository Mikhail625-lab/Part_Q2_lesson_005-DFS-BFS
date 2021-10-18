using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    /// Tree


    class Tree // Kata
    {
        public static List<int> TreeByLevels(Node.Node node)
        {
            //off ya go!
            var l1 = new List<int>();
            l1.Add(node.Value);
            return l1;

        }  // end_of_Tree

    } // end_of_class Tree //


}
