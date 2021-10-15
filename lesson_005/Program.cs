/*
ver: 0.01a date: 2021.10.15
autor: Mikhail625@protonmail.com


Tip: for formatting Ctrl + K, а затем Ctrl + D.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using System.Threading;


namespace GB_Q2_lesson005
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                ............... begin ... ");
            Dispatcher d1 = new Dispatcher();
            d1.Run("T1");
        }
    }// end_of_Main()
    /*
     *

     * */
    class Launch
    { }// end_of_class_Launch

    class Dispatcher
    {
        public void Run(string TaskName)
        {
            bool exit = false;
            string question1 = "\t\tPlease, enter number task (1...5) or 0 (digit  zero)" +
                "\n\t\tand press [Enter] :";
            string question2 = "\t\tOK. Your chice:[{0}]\n\t\tNow runing [Task00{0}]";
            InOut io1 = new InOut();
            Tasks tsk1 = new Tasks();
            int i = 1;
            do
            {
                Console.WriteLine(question1, i);
                i = io1.GetValueFromConsole("");
                switch (i)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("\t\tHave nice day! Buy!");
                        break;
                    case 1:
                        tsk1.Task001();
                        break;
                    case 2:
                        tsk1.Task002();
                        break;
                    case 3:
                        tsk1.Task003();
                        break;
                }
                if (exit == true) { break; }
            } while (i == 0);
        } // enf_of_Run

    }// end_of_class_Dispatcher


    class Tasks  // class Tasks - непосредственно код решения задач 
    {
        public void Task001()
        {
            Console.WriteLine("OK/ Now trying run the  Task001 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
        public void Task002()
        {
            Console.WriteLine("OK/ Now trying run the Task002 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
        public void Task003()
        {
            Console.WriteLine("OK/ Now trying run the Task003 ... ");  //  Run (string TaskName)
            Console.ReadKey();
        }
    } // end class Tasks 

    class InOut
    {
        public int GetValueFromConsole(string textQuestion)
        {
            int result = 0;
            string textQuetionByDef = "\t\tEnter value and press [Enter]:";
            var valueByDef = "1";
            textQuestion = string.IsNullOrEmpty(textQuestion) == true ? textQuetionByDef : textQuestion;
            // Запрос на ввод значения . 
            Console.WriteLine("   " + textQuestion);
            var inputValue = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            // проверка введённого значения на пустоту и далее валидность 
            if (string.IsNullOrEmpty(inputValue) == true)
            {
                result = Convert.ToInt32(valueByDef);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("       " + "Not value, set by default: {0}", valueByDef);
                //Console.WriteLine("\t\tNot value, set by default: {0}", valueByDef);
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");
            }
            else
            {
                if (int.TryParse(inputValue, out result) == true)
                {

                }
                else
                {
                    Console.WriteLine("\t\tError input value or data." +
       "\n\t\tSet value by default or re-enter ?");
                }
            }
            return result;
        }//end_of_GetValueFromConsole
    }

    class Tree // Kata
    {
        public static List<int> TreeByLevels(Node node)
        {
            //off ya go!
            var l1 = new List<int>();
            l1.Add(node.Value);
            return l1;

        }  // end_of_Tree

        public class Node
        {
            public Node Left;
            public Node Right;
            public int Value;
            public bool IsLeaf;
            public bool Visit;

            public Node(Node l, Node r, int v)
            {
                Left = l;
                Right = r;
                Value = v;
                IsLeaf = false;
                Visit = false;
            }
        }



    } // end_of_namespace GB_Q_lesson00
