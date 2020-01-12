using System;
using System.Linq;

namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commmand = string.Empty;
            while ((commmand = Console.ReadLine()) != "Done")
            {
                string[] commandArr = commmand.Split().ToArray();

                if (commandArr[0] == "Change")
                {
                    input = ChangeCommand(input, commandArr);
                }

                else if (commandArr[0] == "Includes")
                {
                    IncludesCommand(input, commandArr);
                }

                else if (commandArr[0] == "End")
                {
                    EndCommand(input, commandArr);
                }

                else if (commandArr[0] == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }

                else if (commandArr[0] == "FindIndex")
                {
                    FindIndexCommand(input, commandArr);
                }

                else if (commandArr[0] == "Cut")
                {
                    input = CutCommand(input, commandArr);
                }
            }
        }

        private static string CutCommand(string input, string[] commandArr)
        {
            int startIndex = int.Parse(commandArr[1]);
            int lenght = int.Parse(commandArr[2]);

            input = input.Substring(startIndex, lenght);
            Console.WriteLine(input);
            return input;
        }

        private static void FindIndexCommand(string input, string[] commandArr)
        {
            char charToFind = char.Parse(commandArr[1]);

            int index = input.IndexOf(charToFind);

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
        }

        private static void EndCommand(string input, string[] commandArr)
        {
            string toEnd = commandArr[1];

            int index = input.IndexOf(toEnd);

            if (input.Length - toEnd.Length == index)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("Flase");
            }
        }

        private static void IncludesCommand(string input, string[] commandArr)
        {
            string includedString = commandArr[1];

            if (input.Contains(includedString))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static string ChangeCommand(string input, string[] commandArr)
        {
            char charToReplace = char.Parse(commandArr[1]);
            char replacement = char.Parse(commandArr[2]);

            input = input.Replace(charToReplace, replacement);
            return input;
        }
    }
}
