using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            numbers.Insert(3, 49);
            Console.WriteLine(string.Join(" ",numbers));
            Console.WriteLine(numbers.Count);

        }
    }
}
