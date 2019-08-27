using System;

namespace Top_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            CheckingForTopNumbers(number);
        }

        private static void CheckingForTopNumbers(int number)
        {
            for (int i = 1; i < number; i++)
            {
                if (SumOfDigitsDivisibleByEight(i) && CheckingForOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool CheckingForOddDigit(int i)
        {
            bool CheckingForOdd = true;
            while (i != 0)
            {
                int lastNumber = i % 10;
                if (lastNumber % 2 != 0)
                    return CheckingForOdd;
                i /= 10;
            }
            return CheckingForOdd = false;
        }

        private static bool SumOfDigitsDivisibleByEight(int i)
        {
            int sum = 0;
            bool divisibleByEight = true;
            while (i != 0)
            {
                int lastNumber = i % 10;
                sum += lastNumber;
                i /= 10;
            }
            if (sum % 8 == 0)
                return divisibleByEight;
            else
            {
                return divisibleByEight = false;
            }
        }
    }
}
