using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int lastDigit = 0;
            int counterSame = 1;
            int sameNumber = 0;
            int max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    if (numbers[i] == lastDigit)
                    {
                        counterSame++;

                        if (counterSame > max)
                        {
                            max = counterSame;
                            sameNumber = lastDigit;
                        }
                    }
                    else
                    {
                        counterSame = 1;
                    }
                }
                lastDigit = numbers[i];
            }
            for (int i = 0; i < max; i++)
            {
                Console.Write($"{sameNumber} ");
            }
        }
    }
}
