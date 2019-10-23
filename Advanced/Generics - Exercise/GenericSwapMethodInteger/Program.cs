using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var input = new List<int>();

            for (int i = 0; i < count; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }
            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            GenericSwapMethodString(input, indexes[0], indexes[1]);
        }

        private static void GenericSwapMethodString<T>(List<T> input, int indexOne, int indexTwo)
        {
            T one = input[indexOne];

            input[indexOne] = input[indexTwo];
            input[indexTwo] = one;

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine($"{input[i].GetType()}: {input[i]}");
            }
        }
    }
}
