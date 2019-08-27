using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int i = 1; i <= number; i++)
            {
                string numberToString = (i).ToString();
                int lenght = numberToString.Length;
                int sumDigits = 0;
                int currentNumber = i;

                for (int t = 0; t < lenght; t++)
                {
                    int lastNumber = currentNumber % 10;
                    currentNumber /= 10;
                    sumDigits += lastNumber;
                }
                if (sumDigits == 5 || sumDigits == 7 || sumDigits == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }


            }
        }
    }
}
