using System;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number > 1)
            {
                int[] fibonaciSeq = new int[number];
                fibonaciSeq[0] = 1;
                fibonaciSeq[1] = 1;

                for (int i = 2; i < number; i++)
                {
                    fibonaciSeq[i] = fibonaciSeq[i - 1] + fibonaciSeq[i - 2];
                }
                Console.WriteLine(fibonaciSeq[number - 1]);
            }

            if (number < 2)
                Console.WriteLine(1);
            
           
        }
    }
}
