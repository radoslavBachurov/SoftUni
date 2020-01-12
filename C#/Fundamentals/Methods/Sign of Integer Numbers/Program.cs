using System;

namespace Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            EvaluateSign(number);
        }

        private static void EvaluateSign(int num)
        {
            if (num > 0)
                Console.WriteLine($"The number {num} is positive");
            else if (num < 0)
                Console.WriteLine($"The number {num} is negative.");
            else if (num == 0)
                Console.WriteLine($"The number 0 is zero.");
        }
    }
}
