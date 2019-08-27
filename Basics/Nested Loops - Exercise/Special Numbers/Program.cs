using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 9999; i++)
            {
                int generatedNumber = i;
                int fourthNumber = generatedNumber % 10;
                generatedNumber /= 10;
                int thirdNumber = generatedNumber % 10;
                generatedNumber /= 10;
                int secondNumber = generatedNumber % 10;
                int firstNumber = generatedNumber / 10;
                if ((fourthNumber == 0) || (secondNumber == 0) || (thirdNumber == 0) || (firstNumber == 0))
                {
                    continue;
                }
                else if (number % fourthNumber == 0 && number % thirdNumber == 0 && number % secondNumber == 0 && number % firstNumber == 0)
                {
                    Console.Write($"{i} ");
                }

            }
        }
    }
}
