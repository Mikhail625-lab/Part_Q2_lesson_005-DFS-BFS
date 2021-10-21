using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOut
{
    // InOut

    class InOut
    {
        public int GetValueFromConsole(string textQuestion)
        {
            int result = 0;
            string textQuetionByDef = "\t\tEnter value and press [Enter]:";
            var valueByDef = "2";
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





}
