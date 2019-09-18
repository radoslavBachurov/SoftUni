using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> ordersQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Count > 0 && foodQuantity >= ordersQueue.Peek())
            {
                foodQuantity -= ordersQueue.Dequeue();
            }

            if(ordersQueue.Count>0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
