using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int divisibleNumber = int.Parse(Console.ReadLine());

            Predicate<int> divisible = x => x % divisibleNumber == 0;
            Func<List<int>, int[]> reverse = x =>
             {
                 int[] reversed = new int[x.Count];
                 int count = 0;
                 for (int i = x.Count - 1; i >= 0; i--)
                 {
                     reversed[i] = x[count];
                     count++;
                 }
                 return reversed;
             };

            numbers.RemoveAll(divisible);
            int[] reversedNumbers = reverse(numbers);
            Console.WriteLine(string.Join(" ",reversedNumbers));

        }
    }
}
