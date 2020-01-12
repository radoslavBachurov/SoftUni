using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupCapacity = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bottleCapacity = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int waterWasted = 0;
            while (cupCapacity.Count > 0 && bottleCapacity.Count > 0)
            {
                int cup = cupCapacity.Peek();
               
                if (cup - bottleCapacity.Peek() <= 0)
                {
                    waterWasted += cup - bottleCapacity.Peek();
                    bottleCapacity.Pop();
                    cupCapacity.Dequeue();
                }
                else
                {
                    while (cup > 0 && bottleCapacity.Count > 0)
                    {
                        cup -= bottleCapacity.Pop();

                        if (cup <= 0)
                        {
                            waterWasted += cup;
                            cupCapacity.Dequeue();
                        }
                    }
                }
            }

            if (bottleCapacity.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupCapacity)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleCapacity)}");
            }

            Console.WriteLine($"Wasted litters of water: {Math.Abs(waterWasted)}");
        }
    }
}
