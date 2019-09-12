using System;
using System.Linq;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string operation = commandArr[0];

                if (operation == "Case")
                {
                    username = ExecutingCaseOperation(username, commandArr);
                }
                else if (operation == "Reverse")
                {
                    ExecutingReverseCommand(username, commandArr);
                }
                else if (operation == "Cut")
                {
                    username = ExecutingCutCommand(username, commandArr);
                }
                else if (operation == "Replace")
                {
                    char character = char.Parse(commandArr[1]);
                    username = username.Replace(character, '*');
                    Console.WriteLine(username);
                }
                else if (operation == "Check")
                {
                    ExecutingCheckCommand(username, commandArr);
                }
            }
        }

        private static void ExecutingCheckCommand(string username, string[] commandArr)
        {
            string character = commandArr[1];

            if (username.Contains(character))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {character}.");
            }
        }

        private static string ExecutingCutCommand(string username, string[] commandArr)
        {
            string subString = commandArr[1];

            if (username.Contains(subString))
            {
                int startIndex = username.IndexOf(subString);
                username = username.Remove(startIndex, subString.Length);
                Console.WriteLine(username);
            }
            else
            {
                Console.WriteLine($"The word {username} doesn't contain {subString}.");
            }

            return username;
        }

        private static void ExecutingReverseCommand(string username, string[] commandArr)
        {
            int startIndex = int.Parse(commandArr[1]);
            int endIndex = int.Parse(commandArr[2]);

            if (startIndex >= 0 && startIndex < username.Length
                && startIndex < endIndex && endIndex < username.Length)
            {
                int numberSymbols = endIndex - startIndex + 1;
                string cut = username.Substring(startIndex, numberSymbols);
                char[] cutCharArray = cut.ToCharArray();
                Array.Reverse(cutCharArray);
                string revercedCut = new string(cutCharArray);
                Console.WriteLine(revercedCut);
            }
        }

        private static string ExecutingCaseOperation(string username, string[] commandArr)
        {
            if (commandArr[1] == "lower")
            {
                username = username.ToLower();
                Console.WriteLine(username);
            }
            else if (commandArr[1] == "upper")
            {
                username = username.ToUpper();
                Console.WriteLine(username);
            }

            return username;
        }
    }
}
