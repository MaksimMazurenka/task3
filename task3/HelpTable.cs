using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class HelpTable
    {
        private static int[,] table;
        private static Rules rules;
        private static Values values;
        private static string[] arguments;
        public HelpTable()
        {
            rules = new Rules();
            values = new Values();
            table = new int[values.Size,values.Size];
            arguments = values.Arguments;
        }
        public void getHelp()
        {
            int hugestString = 0;
            int stringLenth = "Your turns ->".Length;
            for (int i=0; i<arguments.Length; i++)
            {
                hugestString = arguments[i].Length > hugestString ? arguments[i].Length : hugestString;
            }
            if (hugestString > stringLenth)
            {
                stringLenth = hugestString;
            }
            Console.Write(String.Format("{0," + stringLenth + "}", "Your turns ->"));
            for (int k = 0; k < arguments.Length; k++)
            {
                Console.Write(String.Format("{0," + stringLenth + "}", arguments[k]));
            }
            Console.WriteLine();
            for (int i = 0; i < values.Size; i++)
            {
                Console.Write(String.Format("{0," + stringLenth + "}", arguments[i]));
                for (int j = 0; j < values.Size; j++)
                {
                    Console.Write(String.Format("{0," + stringLenth + "}", rules.getResult(i,j)));
                }
                Console.WriteLine();
            }
        }

    }
}
