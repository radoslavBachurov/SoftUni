using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());
            List<string> listOfGuests = new List<string>();

            for (int i = 0; i < numberCommands; i++)
            {
                string command = Console.ReadLine();
                string[] commandToArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command.Contains("not"))
                {
                    if (listOfGuests.Contains(commandToArr[0]))
                    {
                        listOfGuests.Remove(commandToArr[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commandToArr[0]} is not in the list!");
                    }
                }
                else
                {
                    if (listOfGuests.Contains(commandToArr[0]))
                    {
                        Console.WriteLine($"{commandToArr[0]} is already in the list!");
                    }
                    else
                    {
                        listOfGuests.Add(commandToArr[0]);
                    }
                }
            }

            for (int i = 0; i < listOfGuests.Count; i++)
            {
                Console.WriteLine($"{listOfGuests[i]}");
            }
        }
    }
}
