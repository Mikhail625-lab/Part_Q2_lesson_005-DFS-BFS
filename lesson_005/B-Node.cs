using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTreePrinter;

namespace BNode
{
    // from :  https://fooobar.com/questions/128669/c-display-a-binary-search-tree-in-console
    public class BNode
    {
        public int item;
        public BNode right;
        public BNode left;

        public BNode(int item)
        {
            this.item = item;
        }
    }

    public class BTree
    {
        private BNode _root;
        private int _count;
        private IComparer<int> _comparer = Comparer<int>.Default;


        public BTree()
        {
            _root = null;
            _count = 0;
        }


        public bool Add(int Item)
        {
            if (_root == null)
            {
                _root = new BNode(Item);
                _count++;
                return true;
            }
            else
            {
                return Add_Sub(_root, Item);
            }
        }

        private bool Add_Sub(BNode Node, int Item)
        {
            if (_comparer.Compare(Node.item, Item) < 0)
            {
                if (Node.right == null)
                {
                    Node.right = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.right, Item);
                }
            }
            else if (_comparer.Compare(Node.item, Item) > 0)
            {
                if (Node.left == null)
                {
                    Node.left = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.left, Item);
                }
            }
            else
            {
                return false;
            }
        }



        ///*
        public void Print()
        {
            Print(_root, 4);
        }

        public void Print(BNode p, int padding)
        {
            if (p != null)
            {
                if (p.right != null)
                {
                    Print(p.right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.item.ToString() + "\n ");
                if (p.left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.left, padding + 4);
                }
            }
        }

        //*/







    }



    public class Init
    {
        public static void NodesTree(ref BTreePrinter.BNode[] bnod)
        {
            int tmpRnd;
            bool validValue;
            int countEmrg = 1_000;
            int qtyElements = bnod.Length;
            int min1 = 0;
            int max1 = 1_000;

           // List<int> pool1 = new List<int>(qtyElements); // 
            List<int> pool2 = new List<int>(); // список значений Data | Value | Item etc  . Для избежания повоторений and формирования множества 

            // инициализация узлов , присвоение _уникальных_значений
            for (int i = 0; i < qtyElements; i++)
            {
                countEmrg = 0; // на время отладки счётчик анти-бесконечного цикла while
                do
                {
                    countEmrg++;
                    validValue = false;
                    if (countEmrg > 1000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tWarning !! qty iteration of WHILE more 1000");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(min1, max1);
                    if (pool2.IndexOf(tmpRnd) < 0)  // may be null 
                    {
                        pool2.Add(tmpRnd);
                        validValue = true;
                        bnod[i] = new BTreePrinter.BNode(tmpRnd);
                    }
                } while (validValue == true);
            }


            // раздача дочек-сыночков 
            for (int i = 0; i < qtyElements; i++)
            {
                if (pool2.Count() == 0) break;
                if (pool2.Count() == bnod.Count())
                {
                    pool2.Remove(0);
                    // set left  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool2.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool2.Count());
                        bnod[i].left = bnod[tmpRnd];
                        pool2.Remove(tmpRnd);
                    }

                    // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool2.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool2.Count());
                        bnod[i].right = bnod[tmpRnd];
                        pool2.Remove(tmpRnd);
                    }

                } // end_if_(pool

                else
                {
                    // set left  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool2.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool2.Count());
                        bnod[i].left = bnod[tmpRnd];
                        pool2.Remove(tmpRnd);
                    }

                    // set right  direct descendant / direct derivative(прямой потомок)	 декомпоз: вынести в отд метод
                    if (pool2.Count() > 0)
                    {
                        tmpRnd = (int)UtilitesRandom.RandomProvider.GetThreadRandomUIntValue(0, pool2.Count());
                        bnod[i].right = bnod[tmpRnd];
                        pool2.Remove(tmpRnd);
                    }
                }
            } // end_of_for )(int i
            Console.WriteLine("Print?");
            Console.ReadKey();
            BTreePrinter.BTreePrinter.Print(bnod[0]);

            Console.WriteLine("End of initTree");
        } // end_of_InitNodesTree

        public BNode[] SetTree( BNode[] bnod)
        {


            return bnod;
        }
    
    
    }




} // end of Name Space 
