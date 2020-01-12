using System;
using System.Numerics;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber == 0 || secondNumber == 0)
                Console.WriteLine("0");
            else
            {
                BigInteger firstFactorial = CalculateFactorialFromFirstNumber(firstNumber);
                BigInteger secondFactorial = CalculateFactorialFromSecondNumber(secondNumber);
                Console.WriteLine($"{((decimal)firstFactorial / (decimal)secondFactorial):f2}");
            }
        }

        private static BigInteger CalculateFactorialFromSecondNumber(int secondNumber)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= secondNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        private static BigInteger CalculateFactorialFromFirstNumber(int firstNumber)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
