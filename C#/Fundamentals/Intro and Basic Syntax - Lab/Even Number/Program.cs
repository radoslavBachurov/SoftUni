using System;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            while (true)
            {
                
                if (number % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }
                number = Math.Abs(int.Parse(Console.ReadLine()));
            }
        }
    }
}
