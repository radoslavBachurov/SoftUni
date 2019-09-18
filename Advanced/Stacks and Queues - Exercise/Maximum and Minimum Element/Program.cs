using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCommands = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < countCommands; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (input.Length == 1)
                {
                    if (input[0] == 2 && numbers.Count != 0)
                    {
                        numbers.Pop();
                    }
                    else if (input[0] == 3 && numbers.Count != 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                    else if (input[0] == 4 && numbers.Count != 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
                else if (input.Length == 2)
                {
                    numbers.Push(input[1]);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
