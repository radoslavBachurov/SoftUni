using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] commandArr = Console.ReadLine().Split().ToArray();

                if (commandArr.Contains("Include"))
                {
                    shops.Add(commandArr[1]);
                }
                else if (commandArr.Contains("Visit"))
                {
                    ExecutingVisitCommand(commandArr, shops);
                }
                else if (commandArr.Contains("Prefer"))
                {
                    ExecutingPreferCommand(commandArr, shops);
                }
                else if (commandArr.Contains("Place"))
                {
                    ExecutingPlaceCommand(commandArr, shops);
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }

        private static void ExecutingPlaceCommand(string[] commandArr, List<string> shops)
        {
            int index = int.Parse(commandArr[2]);
            string shop = commandArr[1];

            if (index >= 0 && index <= shops.Count)
            {
                shops.Insert(index + 1, shop);
            }
        }

        private static void ExecutingPreferCommand(string[] commandArr, List<string> shops)
        {
            int firstIndex = int.Parse(commandArr[1]);
            int secondIndex = int.Parse(commandArr[2]);
            bool inRange = firstIndex >= 0 && firstIndex < shops.Count
                           && secondIndex >= 0 && secondIndex < shops.Count;
            if (inRange)
            {
                string temp = shops[firstIndex];

                shops[firstIndex] = shops[secondIndex];
                shops[secondIndex] = temp;


            }
        }

        private static void ExecutingVisitCommand(string[] commandArr, List<string> shops)
        {
            if (int.Parse(commandArr[2]) > shops.Count)
            {
                return;
            }

            if (commandArr.Contains("first"))
            {
                for (int i = 0; i < int.Parse(commandArr[2]); i++)
                {
                    shops.RemoveAt(0);
                }

            }
            else if (commandArr.Contains("last"))
            {
                for (int i = 0; i < int.Parse(commandArr[2]); i++)
                {
                    shops.RemoveAt(shops.Count - 1);
                }
            }
        }
    }
}
