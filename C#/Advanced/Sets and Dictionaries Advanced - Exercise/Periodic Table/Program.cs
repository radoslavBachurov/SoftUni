using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> chemicals = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var chemical in input)
                {
                    chemicals.Add(chemical);
                }
            }

            foreach (var chemical in chemicals.OrderBy(x=>x))
            {
                Console.Write(chemical+" ");
            }
        }
    }
}
