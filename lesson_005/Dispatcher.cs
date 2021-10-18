using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    //    internal class Dispatcher


    class Dispatcher
    {
        public void Run(string TaskName)
        {
            bool mustExit = false;
            string question1 = "\t\tPlease, enter number task (1...5) or 0 (digit  zero)" +
                "\n\t\tand press [Enter] :";
            string question2 = "\t\tOK. Your chice:[{0}]\n\t\tNow runing [Task00{0}]";
            InOut.InOut io1 = new InOut.InOut();
            Tasks.Tasks tsk1 = new Tasks.Tasks();
            int i = 1;
            do
            {
                Console.WriteLine(question1, i);
                i = io1.GetValueFromConsole("");
                switch (i)
                {
                    case 0:
                        mustExit = true;
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
                if (mustExit == true) { break; }
            } while (i == 0);
        } // enf_of_Run

    }// end_of_class_Dispatcher


}
