using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
using BNode;
using Launch;
using Dispatcher;
using Tasks;
using InOut;
using Tree;
using Node;
using BTreePrinter;
using UtilitesRandom;
*/


namespace GB_Q2_lesson005
{
    // Tasks

    public class Tasks  // class Tasks - непосредственно код решения задач 
    {
        public void Task001()
        {
            Console.WriteLine("OK/ Now trying run the  Task001 ... ");  //  Run (string TaskName)
            //Console.ReadKey();
            Thread.Sleep(900);
            int qtyNodes = 11;
            Tree tree1 = new Tree();
            Node[] nodes1 = new Node[qtyNodes];
            // https://www.tutlane.com/tutorial/csharp/csharp-list
            // List<Node>[] aln1 = new List<Node>[qtyNodes]; //with List<> пока не получается 
            Node[] an1 = new Node[qtyNodes];

            for (int i = 0; i < qtyNodes; i++)
            {
                an1[i] = new Node() { Value = i * i };
                an1[i].data = i;
            }

            foreach (Node n in an1) { n.DisplayInfo(); }



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
            BNode[] abn1 = new BNode[qtyElements];
            //Console.WriteLine("\t\t Contiue?"); Console.ReadKey();

            /// test without 
            /// 
            string left1; string right1;
            BNode[] abn2 = new BNode[9];

            abn2[8] = new BNode(8);
            abn2[7] = new BNode(7);
            abn2[6] = new BNode(6);
            abn2[6].left = abn2[8];

            abn2[5] = new BNode(5);
            abn2[4] = new BNode(4);
            abn2[3] = new BNode(3);
            abn2[3].right = abn2[7];

            abn2[2] = new BNode(2);
            abn2[2].left = abn2[6];
            abn2[2].right = abn2[5];

            abn2[1] = new BNode(1);
            abn2[1].left = abn2[4];
            abn2[1].right = abn2[3];

            abn2[0] = new BNode(0);
            abn2[0].left = abn2[2];
            abn2[0].right = abn2[1];
            Console.WriteLine("------------------------------------------");
            //BTreePrinter.BTreePrinter.Print(abn2[0]);

            // int tmpRnd;
            bool validValue;
            int countEmrg = 0; // 1_000;
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
                    tmpRnd = (int) RandomProvider.GetThreadRandomUIntValue(min1, max1);
                    if (countEmrg > 100)
                    {
                        Console.WriteLine("!!! Warning !!!! Infinity !!!");
                        break;
                    }

                    if (pool1.IndexOf(tmpRnd) < -1)
                    {
                        Console.WriteLine("\t\t Совпадение ");
                        Console.WriteLine("\t\tgenerate {0}\t\t pool1.IndexOf:{1}   CountEmrg:{2}", tmpRnd, pool1.IndexOf(tmpRnd), countEmrg);
                    }
                    //countEmrg = 0; // на время отладки счётчик анти-бесконечного цикла while
                }
                while (pool1.IndexOf(tmpRnd) < 0);
                abn1[i] = new BNode( tmpRnd ); 
                Console.WriteLine( "\t\ti={0}.\t\titem={1}"  , i ,  abn1[i].item);
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
                        
                            tmpRnd = pool1.ElementAt((int) RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1));
                            abn1[i].left = abn1[tmpRnd];

                            pool1.RemoveAt(tmpRnd);
                            //BTreePrinter.BTreePrinter.Print(abn1[0]);
                            //Console.ReadKey();
                        }

                        // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                        if (pool1.Count() > 0)
                        {
                            tmpRnd = pool1.ElementAt((int) RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1));
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
                            tmpRnd = pool1.ElementAt((int) RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1));
                            abn1[i].left = abn1[tmpRnd];
                            pool1.RemoveAt(tmpRnd);
                            //BTreePrinter.BTreePrinter.Print(abn1[0]);
                            //Console.ReadKey();
                        }

                        // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                        if (pool1.Count() > 0)
                        {
                            tmpRnd = pool1.ElementAt((int) RandomProvider.GetThreadRandomUIntValue(0, pool1.Count() - 1));
                            abn1[i].right = abn1[tmpRnd];
                            pool1.RemoveAt(tmpRnd);
                            //BTreePrinter.BTreePrinter.Print(abn1[0]);
                            //Console.ReadKey();

                        }
                    }

                    left1 = string.IsNullOrEmpty((abn1[i].left.item).ToString()) == true ? "" : ((abn1[i].left.item).ToString());
                    right1 = (string.IsNullOrEmpty((abn1[i].right.item).ToString()) )== true ? "" : ((abn1[i].right.item).ToString());
                    Console.WriteLine("\t\titem:[{0}]\tleft:[{1}]\tright:[{2}]", abn1[i].item, left1, right1);
                } // end_of_for )(int i

                BTreePrinter.Print(abn1[0]);
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
