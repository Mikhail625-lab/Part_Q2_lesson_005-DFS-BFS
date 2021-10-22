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

            for (int i = 0; i < qtyNodes; i++)
            {
                an1[i] = new Node.Node() { Value = i * i };
                an1[i].data = i;
            }

            foreach (Node.Node n in an1) { n.DisplayInfo(); }



            Console.WriteLine("\t\tThat's all"); Console.ReadKey();
        }
        public void Task002()
        {

            Console.WriteLine("\t\t\tOK Now trying run the Task002 ... Input qtyElements:");  //  Run (string TaskName)
            var qtyElements = Convert.ToInt32(Console.ReadLine());
            // block init 
            // int qtyElements = 11;
            int min1 = 0;
            int max1 = 1221;
            int tmpRnd = 0;
            BTreePrinter.BNode[] abn1 = new BTreePrinter.BNode[qtyElements];
            //Console.WriteLine("\t\t Contiue?"); Console.ReadKey();

            /// test without 
            /// 
            string left1; string right1;
            BTreePrinter.BNode[] abn2 = new BTreePrinter.BNode[9];

            abn2[8] = new BTreePrinter.BNode(8);
            abn2[7] = new BTreePrinter.BNode(7);
            abn2[6] = new BTreePrinter.BNode(6);
            abn2[6].left = abn2[8];

            abn2[5] = new BTreePrinter.BNode(5);
            abn2[4] = new BTreePrinter.BNode(4);
            abn2[3] = new BTreePrinter.BNode(3);
            abn2[3].right = abn2[7];

            abn2[2] = new BTreePrinter.BNode(2);
            abn2[2].left = abn2[6];
            abn2[2].right = abn2[5];

            abn2[1] = new BTreePrinter.BNode(1);
            abn2[1].left = abn2[4];
            abn2[1].right = abn2[3];

            abn2[0] = new BTreePrinter.BNode(0);
            abn2[0].left = abn2[2];
            abn2[0].right = abn2[1];

            //BTreePrinter.BTreePrinter.Print(abn2[0]);

            // int tmpRnd;
            bool validValue;
            int countEmrg = 1_000;
            int qtyElmn = abn1.Length;
            // int min1 = 0;
            // int max1 = 1_000;
            List<int> pool1 = new List<int>(); // список значений Data | Value | Item etc  . Для избежания повоторений and формирования множества 

            //pool1.Add(new BNode() { Name = "Том" })
            // инициализация узлов , присвоение _уникальных_значений
            for (int i = 0; i < qtyElmn; i++)
            {

                // для обеспечения уникальности
                
                do
                {
                    countEmrg++;
                    tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(min1, max1);
                    if (countEmrg > 100)
                    {
                        Console.WriteLine("!!! Warning !!!! Infinity !!!");
                        break;
                    }
                    Console.WriteLine("\t\tgenerate {0}   {1}   CountEmrg:{2}" , tmpRnd , pool1.IndexOf(tmpRnd) , countEmrg);
                }
                //countEmrg = 0; // на время отладки счётчик анти-бесконечного цикла while
                while (pool1.IndexOf(tmpRnd) < 0);
                abn1[i] = new BTreePrinter.BNode(tmpRnd);
                pool1.Add(tmpRnd);
                countEmrg = 0;

            }


            // раздача дочек-сыночков 
            for (int i = 0; i < qtyElmn; i++)
            {
                if (pool1.Count() == 0) break;
                if (i == 0)  // if (pool1.Count() == abn1.Count())
                {
                    pool1.RemoveAt(0);
                    // set left  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool1.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1);
                        abn1[i].left = abn1[tmpRnd];
                        pool1.RemoveAt(tmpRnd);
                        //BTreePrinter.BTreePrinter.Print(abn1[0]);
                        //Console.ReadKey();
                    }

                    // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool1.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1);
                        abn1[i].right = abn1[tmpRnd];
                        pool1.RemoveAt(tmpRnd);
                        // BTreePrinter.BTreePrinter.Print(abn1[0]);
                        //Console.ReadKey();
                    }

                } // end_if_(pool

                else
                {
                    // set left  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool1.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1);
                        abn1[i].left = abn1[tmpRnd];
                        pool1.RemoveAt(tmpRnd);
                        //BTreePrinter.BTreePrinter.Print(abn1[0]);
                        //Console.ReadKey();
                    }

                    // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool1.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1);
                        abn1[i].right = abn1[tmpRnd];
                        pool1.RemoveAt(tmpRnd);
                        //BTreePrinter.BTreePrinter.Print(abn1[0]);
                        //Console.ReadKey();

                    }
                }

                left1  = string.IsNullOrEmpty((abn1[i].left.item).ToString())  == true ? "" : ((abn1[i].left.item).ToString());
                right1 = string.IsNullOrEmpty((abn1[i].right.item).ToString()) == true ? "" : ((abn1[i].right.item).ToString());
                Console.WriteLine("\t\titem:[{0}]\tleft:[{1}]\tright:[{2}]", abn1[i].item, left1, right1);
            } // end_of_for )(int i

            //BTreePrinter.BTreePrinter.Print(abn1[0]);
            Console.WriteLine("End of initTree");
            Console.ReadKey();
            /*
            foreach (var n1 in abn1)
            { Console.WriteLine("item:[{0}]\t\t left:[{1}]\t\t right:[{2}]", n1.item, n1.left, n1.right);
            }
            */



            Console.WriteLine("\t\tThats all for task #2"); Console.ReadKey();
        }
        public void Task003()
        {
            Console.WriteLine("OK/ Now trying run the Task003 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
    } // end class Tasks 



}
