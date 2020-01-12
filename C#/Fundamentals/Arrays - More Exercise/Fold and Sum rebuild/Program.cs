using System;
using System.Linq;

namespace Fold_and_Sum_rebuild
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = numbers.Length / 4;
            int seqLong = k * 2;

            int[] sideNumbers = new int[seqLong];

            for (int i = 0; i < seqLong/2; i++)
            {
                sideNumbers[i] = numbers[k - 1 - i];
                sideNumbers[seqLong / 2+i] = numbers[numbers.Length - 1 - i];
            }

            int[] centerNumbers = new int[seqLong];

            for (int i = 0; i < seqLong; i++)
            {
                centerNumbers[i] = numbers[k+i];
                Console.Write($"{sideNumbers[i]+centerNumbers[i]}"+" ");
            }
        }
    }
}
