using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            if (times <= 10)
            {
                for (int i = times; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {i} = {number * i}");
                }
            }
            else
                Console.WriteLine($"{number} X {times} = {number*times}");
        }
    }
}
