using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int digit = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int t = i+1; t < numbers.Length; t++)
                {
                    if(numbers[i]+numbers[t]==digit)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[t]}");
                    }
                }
            }
        }
    }
}
