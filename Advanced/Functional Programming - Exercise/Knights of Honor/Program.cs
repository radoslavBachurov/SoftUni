using System;
using System.Collections.Generic;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> AddingSirAndPrint = Printing;

            var input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            AddingSirAndPrint(input);
        }
        public static void Printing(string[] input)
        {
            foreach (var name in input)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
