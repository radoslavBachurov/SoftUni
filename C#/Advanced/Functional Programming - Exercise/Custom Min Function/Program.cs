using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findingMin = x =>
             {
                 int min = int.MaxValue;

                 foreach (int number in x)
                 {
                     if (number < min)
                     {
                         min = number;
                     }
                 }
                 return min;
             };

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"{findingMin(input).ToString()}");
        }
    }
}
