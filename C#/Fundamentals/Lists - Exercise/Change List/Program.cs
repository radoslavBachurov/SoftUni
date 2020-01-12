using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                if (command.Contains("Delete"))
                {
                    numbers.RemoveAll(x => x==int.Parse(commandArr[1]));
                }
                else if (command.Contains("Insert"))
                {
                    numbers.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]));
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
