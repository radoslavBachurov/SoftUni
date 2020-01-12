using System;
using System.Collections.Generic;



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
                int fifthDigit = i % 10;
                i /= 10;
                int fourthDigit = i % 10;
                i /= 10;
                int thirdDigit = i % 10;
                i /= 10;
                int secondDigit = i % 10;
                int firstDigit = i / 10;

                if (fifthDigit + fourthDigit == secondDigit + firstDigit)
                    Console.Write($"{j} ");
                
                else if (fifthDigit + fourthDigit < secondDigit + firstDigit)
                {
                    int sum = fifthDigit + fourthDigit + thirdDigit;

                    if (sum == secondDigit + firstDigit)
                    {
                        Console.Write($"{j} ");
                    }
                }

                else if (fifthDigit + fourthDigit > secondDigit + firstDigit)
                {
                    int sum = secondDigit + firstDigit + thirdDigit;

                    if (sum == fifthDigit + fourthDigit)
                    {
                        Console.Write($"{j} ");
                    }
                    
                }
            }
        }
    }
}

