using System;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumofEven = GetSumOfEvenDigits(number);
            int sumofOdd = GetofOddDigits(number);
            int multiplyEvenOdd = GetMultipleOfEvenAndOdds(sumofEven, sumofOdd);

            Console.WriteLine(multiplyEvenOdd);
}

        private static int GetMultipleOfEvenAndOdds(int sumofEven, int sumofOdd)
        {
            return sumofOdd * sumofEven;
        }

        private static int GetofOddDigits(int number)
        {
            int sumOdd = 0;
            while (number != 0)
            {
                int lastNumber = number % 10;

                if (lastNumber % 2 != 0)
                    sumOdd += lastNumber;

                number /= 10;
            }
            return sumOdd;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sumEven = 0;
            while (number != 0)
            {
                int lastNumber = number % 10;

                if (lastNumber % 2 == 0)
                    sumEven += lastNumber;

                number /= 10;
            }
            return sumEven;
        }
    }
}
