using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 1; i <= countNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumEven += number;
                }
                else if (i % 2 != 0)
                {
                    sumOdd += number;
                }
            }

            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }

            else if (sumOdd != sumEven)
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven-sumOdd)}");
            }
        }
    }
}
