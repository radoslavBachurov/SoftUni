using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> myComparer = (a, b) =>
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    if (a < b)
                    {
                        return -1;
                    }
                    if (a > b)
                    {
                        return 1;
                    }
                    return 0;
                }
                if (a % 2 != 0 && b % 2 != 0)
                {
                    if (a < b)
                    {
                        return -1;
                    }
                    if (a > b)
                    {
                        return 1;
                    }
                    return 0;
                }
                if (a % 2 == 0)
                {
                    return -1;
                }
                if (a % 2 != 0)
                {
                    return 1;
                }
                return 0;
            };

            Array.Sort(numbers, new Comparison<int>(myComparer));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
