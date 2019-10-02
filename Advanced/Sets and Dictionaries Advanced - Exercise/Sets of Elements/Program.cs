using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberSets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < numberSets[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numberSets[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (int number in firstSet)
            {
                if(secondSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
