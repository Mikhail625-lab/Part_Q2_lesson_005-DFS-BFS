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


namespace GB_Q_lesson005
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("begin");
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

            string question1 = "\t\tEnter number task (1...5) and press [Enter]:";
            InOut io1 = new InOut();

            int i = 1;
            do
            {
                i = io1.GetValueFromConsole("");
                Console.ReadKey();

            }

            while (i < 100);



        }

    }// end_of_class_Dispatcher


    class Tasks  // class Tasks - непосредственно код решения задач 
    {
        public void Task001()
        {
            Console.WriteLine("OK/ Now trying run the .. ");  //  Run (string TaskName)
            Console.ReadKey();
        }

    } // end class Tasks 

    class InOut
    {
        public int GetValueFromConsole(string textQuestion)
        {
            int result = 0;
            string textQuetionByDef = "\t\tPlease, enter number task (1...5) and press [Enter] :";
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
                    Console.WriteLine("\t\tError input value or data." +
                        "\n\t\tSet value by default or re-enter ?");
                }
            }
            return result;
        }//end_of_GetValueFromConsole
    }


} // end_of_namespace GB_Q_lesson00
