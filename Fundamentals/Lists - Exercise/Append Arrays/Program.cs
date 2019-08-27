using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split("|").ToList();
            numbers.Reverse();
            List<int> intNumbers = new List<int>();
            foreach (var item in numbers)
            {
                int digits = item.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            }

            Console.WriteLine(string.Join(" ",intNumbers));
            
        }
    }
}
