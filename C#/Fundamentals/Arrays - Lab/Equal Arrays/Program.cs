using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrOne = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] arrTwo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < arrOne.Length; i++)
            {
                if (arrOne[i] == arrTwo[i])
                    sum += arrOne[i];
                else if (arrOne[i] != arrTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
