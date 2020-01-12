using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = Console.ReadLine().Split(" ").Select(int.Parse).Where(x => x > 0).ToList();
            Numbers.Reverse();
            if (Numbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ",Numbers));
            }
            else
                Console.WriteLine("empty");
        }
    }
}
