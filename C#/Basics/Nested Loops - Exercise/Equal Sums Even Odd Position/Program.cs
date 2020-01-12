using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int j = firstNumber; j <= secondNumber; j++)
            {
                int i = j;
                int sixDigit = i % 10;
                i /= 10;
                int fifthDigit = i % 10;
                i /= 10;
                int fourthDigit = i % 10;
                i /= 10;
                int thirdDigit = i % 10;
                i /= 10;
                int secondDigit = i % 10;
                int firstDigit = i/10;
                if((sixDigit+fourthDigit+secondDigit) == (firstDigit+thirdDigit+fifthDigit))
                {
                    Console.Write($"{j} ");
                }

            }
        }
    }
}
