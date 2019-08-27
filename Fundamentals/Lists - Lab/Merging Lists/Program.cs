using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstUnits = Console.ReadLine().Split(" ").ToList();
            List<string> secondUnits = Console.ReadLine().Split(" ").ToList();

            List<string> mergedUnits = new List<string>();

            for (int i = 0; i < Math.Max(firstUnits.Count,secondUnits.Count); i++)
            {
                if(i < firstUnits.Count)
                {
                    mergedUnits.Add(firstUnits[i]);
                }
                if(i < secondUnits.Count)
                {
                    mergedUnits.Add(secondUnits[i]);
                }
            }

            Console.WriteLine(string.Join(" ",mergedUnits));
        }
    }
}
