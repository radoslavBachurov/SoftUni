using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;

            for (int i = 1; counter < count; i++)
            {
                if (i % 2 != 0)
                {
                    counter++;
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
