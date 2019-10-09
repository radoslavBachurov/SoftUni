using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .Select(x => x.ToString("f2"))
                .ToArray();

            foreach (var number in prices)
            {
                Console.WriteLine(number);
            }
        }
    }
}
