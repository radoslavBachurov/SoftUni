using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double maxEven = int.MinValue;
            double minEven = int.MaxValue;
            double maxOdd = int.MinValue;
            double minOdd = int.MaxValue;
            double sumEven = 0;
            double sumOdd = 0;

            for (int i = 1; i <= count; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumEven += number;
                    if (number > maxEven)
                    {
                        maxEven = number;
                    }
                    if (number < minEven)
                    {
                        minEven = number;
                    }
                }

                else if (i % 2 != 0)
                {
                    sumOdd += number;
                    if (number > maxOdd)
                    {
                        maxOdd = number;
                    }
                    if (number < minOdd)
                    {
                        minOdd = number;
                    }
                }


            }
            if (sumEven == 0 && sumOdd == 0)
            {
                Console.WriteLine($"OddSum={sumOdd:f2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={sumEven:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }

            else if (sumOdd == 0)
            {
                Console.WriteLine($"OddSum={sumOdd:f2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={sumEven:f2},");
                Console.WriteLine($"EvenMin={minEven:f2},");
                Console.WriteLine($"EvenMax={maxEven:f2}");
            }
            else if (sumEven == 0)
            {
                Console.WriteLine($"OddSum={sumOdd:f2},");
                Console.WriteLine($"OddMin={minOdd:f2},");
                Console.WriteLine($"OddMax={maxOdd:f2},");
                Console.WriteLine($"EvenSum={sumEven:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"OddSum={sumOdd:f2},");
                Console.WriteLine($"OddMin={minOdd:f2},");
                Console.WriteLine($"OddMax={maxOdd:f2},");
                Console.WriteLine($"EvenSum={sumEven:f2},");
                Console.WriteLine($"EvenMin={minEven:f2},");
                Console.WriteLine($"EvenMax={maxEven:f2}");
            }
            
        }
    }
}
