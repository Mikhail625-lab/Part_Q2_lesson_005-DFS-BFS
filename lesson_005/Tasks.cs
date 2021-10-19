using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using BNode;
using Launch;
using Dispatcher;
using Tasks;
using InOut;
using Tree;
using Node;
using BTreePrinter;
using UtilitesRandom;



namespace Tasks
{
    // Tasks

    class Tasks  // class Tasks - непосредственно код решения задач 
    {
        public void Task001()
        {
            Console.WriteLine("OK/ Now trying run the  Task001 ... ");  //  Run (string TaskName)
            //Console.ReadKey();
            Thread.Sleep(900);
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

            // block init 
            int qtyElements = 11;
            int min1 = 0;
            int max1 = 1221;
            int tmpRnd = 0;
            BTreePrinter.BTreePrinter.BNode[] abn1 = new BTreePrinter.BTreePrinter.BNode[qtyElements];
            List<int> pool = new List<int>(qtyElements);
            
            for (int i = 0; i < qtyElements; i++)
            {
                tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(min1, max1);
                abn1[i] = new BTreePrinter.BTreePrinter.BNode(tmpRnd);
            }


            Random rand = new Random();
            for (int i = 0; i < qtyElements; i++)
            {
                tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(i + 1, qtyElements - 1);
                abn1[i].left = abn1[tmpRnd];
                tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(i + 1, qtyElements - 1);
                abn1[i].right = abn1[tmpRnd];

                if (rand.Next(0, 1) == 1)
                {
                    abn1[i].left = abn1[tmpRnd];
                }
                else
                {
                    tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(i + 1, qtyElements - 1);
                    abn1[i].right = abn1[tmpRnd];
                }

                if (i + 1 == qtyElements - 1) break;
            }

            Console.WriteLine("\t\tPrint?"); Console.ReadKey();

            foreach (var n1 in abn1)
            {
                Console.WriteLine("item:[{0}]\t\t left:[{1}]\t\t right:[{2}]" , n1.item  , n1.left , n1.right);
            }

            //BTreePrinter.BTreePrinter.Print(abn1[0]);
            Console.WriteLine("\t\tThats all"); Console.ReadKey();
        }
        public void Task003()
        {
            Console.WriteLine("OK/ Now trying run the Task003 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
    } // end class Tasks 



}
