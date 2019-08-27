using System;
using System.Linq;


namespace From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                long max = long.MinValue; ;
                long sum = 0;
                long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                for (int t = 0; t < 2; t++)
                {
                    if (numbers[t] > max)
                        max = numbers[t];
                }
                while (max != 0)
                {
                    long lastDigit = max % 10;
                    max /= 10;
                    sum += lastDigit;
                }
                Console.WriteLine(Math.Abs(sum));

            }


        }
    }
}
