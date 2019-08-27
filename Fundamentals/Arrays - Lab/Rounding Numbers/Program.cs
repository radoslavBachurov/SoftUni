using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (var digits in numbers)
            {
                Console.WriteLine($"{digits} => {Math.Round(digits,MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
