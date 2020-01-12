using System;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] numbers = Console.ReadLine().TrimStart(new char[] { '0' }).ToCharArray();
            int number = int.Parse(Console.ReadLine());
            string endNumber = string.Empty;
            int toNext = 0;


            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (number == 0)
                {
                    endNumber += "0";
                    break;
                }

                int digit = int.Parse(numbers[i].ToString());

                int product = number * digit + toNext;

                if (i == 0)
                {
                    int toCurrent = product;
                    char[] lastDigitsArr = toCurrent.ToString().ToCharArray();
                    Array.Reverse(lastDigitsArr);
                    endNumber += string.Join("", lastDigitsArr);
                }

                else 
                {
                    int toCurrent = product % 10;
                    toNext = product / 10;

                    endNumber += toCurrent.ToString();
                }
            }

            char[] endNumberArr = endNumber.ToCharArray();
            Array.Reverse(endNumberArr);
            Console.WriteLine(string.Join("", endNumberArr));
        }
    }
}
