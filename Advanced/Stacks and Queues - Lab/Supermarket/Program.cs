using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> newQueue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid" && newQueue.Count > 0)
                {
                    int count = newQueue.Count;

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(newQueue.Dequeue());
                    }
                }
                else
                {
                    newQueue.Enqueue(input);
                }
            }

            Console.WriteLine($"{newQueue.Count} people remaining.");
        }
    }
}
