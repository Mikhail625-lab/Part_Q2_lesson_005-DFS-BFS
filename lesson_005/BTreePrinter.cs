using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BNode;



namespace BTreePrinter
{
    //internal class BeTreePrinter

    public static class BTreePrinter
    {
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

        class NodeInfo
        {
            public BNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(this BNode root, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.item.ToString(" 0 ") };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }


        public static void InitNodesTree(ref BTreePrinter.BNode[] bnod)
        {
            int tmpRnd;
            bool validValue;
            int countEmrg = 1_000;
            int qtyElements = bnod.Length;
            int min1 = 0;
            int max1 = 1_000;


            List<int> pool1 = new List<int>(qtyElements); // 
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
                        bnod[i] = new BNode(tmpRnd);
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
            Console.WriteLine("End of initTree");
        } // end_of_InitNodesTree

    }




}// end of namespase 
