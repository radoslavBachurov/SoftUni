using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int sumNumbers = 0;
            int lastSum = 0;
            int maxDiff = int.MinValue;

            for (int i = 0; i < countNumbers; i++)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                sumNumbers = number1 + number2;
                if (i > 0)
                {
                    int diff = Math.Abs(sumNumbers - lastSum);
                    if (diff > maxDiff && diff != 0)
                    {
                        maxDiff = diff;
                    }
                }
                lastSum = sumNumbers;
            }

            if (maxDiff == int.MinValue)
            {
                Console.WriteLine($"Yes, value={sumNumbers}");
            }
           else if (maxDiff != int.MinValue)
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }

        }
    }
}
