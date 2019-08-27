using System;
using System.Linq;

namespace First_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandsArr = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commandsArr[0];

                if (command == "Translate")
                {
                    char toReplace = char.Parse(commandsArr[1]);
                    char charGiven = char.Parse(commandsArr[2]);

                    input = input.Replace(toReplace, charGiven);
                    Console.WriteLine(input);
                }
                else if (command == "Includes")
                {
                    string stringToFind = commandsArr[1];

                    if (input.Contains(stringToFind))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Start")
                {
                    string stringStart = commandsArr[1];

                    int index = input.IndexOf(stringStart);
                    if (index == 0)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command == "FindIndex")
                {
                    char givenChar = char.Parse(commandsArr[1]);
                    int index = input.LastIndexOf(givenChar);
                    Console.WriteLine(index);
                }
                else if (command == "Remove")
                {
                    int startIndex = int.Parse(commandsArr[1]);
                    int count = int.Parse(commandsArr[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
