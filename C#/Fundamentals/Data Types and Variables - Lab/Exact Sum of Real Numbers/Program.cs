using System;
using System.Numerics;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDigits = int.Parse(Console.ReadLine());
             decimal sum = 0m;

            for (int i = 0; i < numberDigits; i++)
            {
                sum += decimal.Parse(Console.ReadLine());

            }
            Console.WriteLine(sum);
        }
    }
}
