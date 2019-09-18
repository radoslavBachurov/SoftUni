using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int rackInitialCapacity = int.Parse(Console.ReadLine());
            int rackCapacity = rackInitialCapacity;
            int rackCount = 1;

            while (clothes.Count > 0)
            {
                if (rackCapacity - clothes.Peek() < 0)
                {
                    rackCount++;
                    rackCapacity = rackInitialCapacity;
                }

                rackCapacity -= clothes.Pop();
            }

            Console.WriteLine(rackCount);
        }
    }
}
