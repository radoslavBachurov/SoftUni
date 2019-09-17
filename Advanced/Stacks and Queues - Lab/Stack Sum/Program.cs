using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> newStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            string command = string.Empty;

            while ((command = Console.ReadLine()?.ToLower()) != "end")
            {
                string[] commandArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(commandArr[0]=="add")
                {
                    for (int i = 1; i < commandArr.Length; i++)
                    {
                        newStack.Push(int.Parse(commandArr[i]));
                    }
                }
                else if(commandArr[0]=="remove")
                {
                    int removeCount = int.Parse(commandArr[1]);

                    if(removeCount>newStack.Count)
                    {
                        continue;
                    }

                    for (int i = 1; i <= removeCount; i++)
                    {
                        newStack.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {newStack.Sum()}");
        }
    }
}
