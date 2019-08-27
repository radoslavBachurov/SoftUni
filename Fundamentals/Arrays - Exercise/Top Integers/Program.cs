using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                bool bigger = true;
                for (int t = numbers.Length - 1; t > i; t--)
                {
                    if (numbers[i] <= numbers[t])
                        bigger = false;
                }
                if (bigger)
                    Console.Write($"{numbers[i]} ");
            }
            
        }
    }
}
