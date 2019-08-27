using System;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = string.Empty;
            while ((number = Console.ReadLine()) != "END")
            {

                CheckingForPalindrome(number);
            }
        }

        private static void CheckingForPalindrome(string number)
        {
            int firstNumber = int.Parse(number);
            string secondNumberStr = string.Empty;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                secondNumberStr += number[i].ToString();
            }

            int secondNumber = int.Parse(secondNumberStr);

            if (firstNumber == secondNumber)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
