using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] websites = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var smartPhone = new SmartPhone();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsDigitsOnly(numbers[i]))
                {
                    Console.WriteLine(smartPhone.Call(numbers[i]));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < websites.Length; i++)
            {
                if (IsLetterOrSymbol(websites[i]))
                {
                    Console.WriteLine(smartPhone.Browse(websites[i]));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private static bool IsLetterOrSymbol(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsPunctuation(c) && !char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
