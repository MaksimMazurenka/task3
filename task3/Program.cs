using NHibernate.Engine;
using NHibernate.Mapping;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length % 2 == 0 || args.Length<3)
            {
                Console.Clear();
                Console.WriteLine("Please, enter odd number of moves greater than or equal to 3");
                String chuseAgain = Console.ReadLine();
            }
            else
            {
                Values values = new Values(args);
                HMACGenerator generator = new HMACGenerator(values.Size);
                generator.keyGenerator();
                generator.HMACHASH(args[generator.getPcTurn()], generator.getKey());
                Console.WriteLine("HMAC:" + generator.getHMAC());
                meny(args);
                HashSet<String> set = new HashSet<String>();
                for(int i=0;i<args.Length;i++)
                {
                    set.Add(args[i]);
                }
                if(set.Count != args.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Moves must not have the same names");
                    String chuseAgain = Console.ReadLine();
                }
                else
                {
                    String chuse = Console.ReadLine();
                    userChoise(chuse, args, generator);
                }
            }           
        }

        public static void meny(string[] args)
        {
            Console.WriteLine("Available moves:");
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < args.Length; i++){
                result.Append(i+1);
                result.Append(" - ");
                result.Append(args[i]);
                Console.WriteLine(result);
                result.Clear();
            }
            result.Append("0 - exit");
            Console.WriteLine(result);
            result.Clear();
            result.Append("? - help");
            Console.WriteLine(result);
            result.Clear();
            result.Append("Enter your move: ");
            Console.WriteLine(result);
        }

        public static void userChoise(String chuse, string[] args, HMACGenerator HMAC)
        {
            if (!chuse.Equals("?"))
            {
                int chosenValue = -1;
                try
                {
                    chosenValue = int.Parse(chuse);
                    if (chosenValue > args.Length)
                    {
                        Console.Clear();
                        Console.WriteLine("Your move number is not in the range of available moves. Please enter a valid move");
                        HMAC.keyGenerator();
                        HMAC.HMACHASH(args[HMAC.getPcTurn()], HMAC.getKey());
                        Console.WriteLine("HMAC:" + HMAC.getHMAC());
                        meny(args);
                        String chuseAgain = Console.ReadLine();
                        userChoise(chuseAgain, args, HMAC);
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input format. You shoult input '?' or number of your move");
                    HMAC.keyGenerator();
                    HMAC.HMACHASH(args[HMAC.getPcTurn()], HMAC.getKey());
                    Console.WriteLine("HMAC:" + HMAC.getHMAC());
                    meny(args);
                    String chuseAgain = Console.ReadLine();
                    userChoise(chuseAgain, args,  HMAC);
                }
                if (chosenValue != 0)
                {
                    Rules rules = new Rules(); 
                    Console.Write("Your move: ");
                    Console.Write(args[chosenValue-1]);
                    Console.WriteLine();
                    Console.Write("Computer move: ");
                    Console.Write(args[HMAC.getPc()]);
                    Console.WriteLine();
                    Console.WriteLine(rules.getResult(HMAC.getPc(), chosenValue - 1));
                    Console.WriteLine("HMAC key:" + HMAC.getStringKey());
                    Console.ReadKey();
                    Console.Clear();
                    HMAC.keyGenerator();
                    HMAC.HMACHASH(args[HMAC.getPcTurn()], HMAC.getKey());
                    Console.WriteLine("HMAC:" + HMAC.getHMAC());
                    meny(args);
                    String chuseAgain = Console.ReadLine();
                    userChoise(chuseAgain, args, HMAC);
                }
            }
            else
            {
                Console.Clear();
                HelpTable helpTable = new HelpTable();
                helpTable.getHelp();
                HMAC.keyGenerator();
                HMAC.HMACHASH(args[HMAC.getPcTurn()], HMAC.getKey());
                Console.WriteLine("HMAC:" + HMAC.getHMAC());
                meny(args);
                String chuseAgain = Console.ReadLine();
                userChoise(chuseAgain, args,HMAC);
            }
        }
    }
}
