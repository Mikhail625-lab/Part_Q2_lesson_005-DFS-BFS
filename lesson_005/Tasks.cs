using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    // Tasks

    class Tasks  // class Tasks - непосредственно код решения задач 
    {
        public void Task001()
        {
            Console.WriteLine("OK/ Now trying run the  Task001 ... ");  //  Run (string TaskName)
            //Console.ReadKey();
            Thread.Sleep(100);
            int qtyNodes = 11;
            Tree.Tree tree1 = new Tree.Tree();
            Node.Node[] nodes1 = new Node.Node[qtyNodes];
            // https://www.tutlane.com/tutorial/csharp/csharp-list
            // List<Node>[] aln1 = new List<Node>[qtyNodes]; //with List<> пока не получается 
            Node.Node[] an1 = new Node.Node[qtyNodes];
            //people.Add(new Person() { Name = "Том" })
            for (int i = 0; i < qtyNodes; i++)
            {
                an1[i] = new Node.Node() { Value = i * i };
                an1[i].data = i;
            }

            foreach (Node.Node n in an1)
            { n.DisplayInfo(); }

            Console.WriteLine("\t\tThat's all"); Console.ReadKey();
        }
        public void Task002()
        {
            Console.WriteLine("OK/ Now trying run the Task002 ... ");  //  Run (string TaskName)
            //Console.ReadKey();
            for (int i = 0; i < 22; i++)
            {
                Console.WriteLine("RandomProvider" + "\t\t" + Utilites_Random.RandomProvider.GetThreadRandomStringValue(1, 40));
            }

        }
        public void Task003()
        {
            Console.WriteLine("OK/ Now trying run the Task003 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
    } // end class Tasks 



}
