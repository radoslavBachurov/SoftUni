using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numberQueue = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int popNumber = input[1];
            int searchNumber = input[2];

            for (int i = 0; i < popNumber; i++)
            {
                numberQueue.Pop();
            }

            if(numberQueue.Contains(searchNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numberQueue.Count > 0)
                {
                    int min = numberQueue.Min();
                    Console.WriteLine(min);
                }
                else
                {
                    Console.WriteLine(0);
                }
                
            }
        }
    }
}
