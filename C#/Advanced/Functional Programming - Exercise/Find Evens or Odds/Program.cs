using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> sortEvenNumbers = x => x % 2 == 0;
            Action<List<int>> printing = x => Console.WriteLine(string.Join(" ", x));

            int[] range = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            string typeNumbers = Console.ReadLine();

            if(typeNumbers=="even")
            {
                numbers.RemoveAll(x=>!sortEvenNumbers(x));
            }
            else
            {
                numbers.RemoveAll(x => sortEvenNumbers(x));
            }

            printing(numbers);
        }
    }
}
