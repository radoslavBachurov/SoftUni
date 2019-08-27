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

            int lastsum = 0;

            int maxDiff = int.MinValue;


            for (int i = 0; i < countNumbers; i++)
            {
                int currentDiff = 0;
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                int sum = number1 + number2;

                if (i == 0)
                {
                    lastsum = sum;
                }
                if (lastsum != sum)
                {
                    currentDiff = Math.Abs(lastsum - sum);
                    if (currentDiff > maxDiff)
                    {
                        maxDiff = currentDiff;
                    }
                }
                lastsum = sum;

            }
            if (int.MinValue != maxDiff)
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
            else
            {
                Console.WriteLine($"Yes, value={lastsum}");
            }
        }
    }
}
