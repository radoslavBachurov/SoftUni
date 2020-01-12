using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDigits = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < numberDigits; i++)
            {
                int sum1 = int.Parse(Console.ReadLine());
                firstSum += sum1;
            }

            for (int i = 0; i < numberDigits; i++)
            {
                int sum2 = int.Parse(Console.ReadLine());
                secondSum += sum2;
            }

            if (secondSum == firstSum)
            {
                Console.WriteLine($"Yes, sum = {secondSum}");
            }
            else if (secondSum != firstSum)
            {
                Console.WriteLine($"No, diff = {Math.Abs(secondSum-firstSum)}");
            }
        }
    }
}
