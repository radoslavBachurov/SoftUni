using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> newQueue = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int count = int.Parse(Console.ReadLine());

            while (newQueue.Count > 1)
            {
                for (int i = 0; i < count-1; i++)
                {
                    string kidToPass = newQueue.Dequeue();
                    newQueue.Enqueue(kidToPass);
                }

                Console.WriteLine($"Removed {newQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {newQueue.Dequeue()}");
        }
    }
}
