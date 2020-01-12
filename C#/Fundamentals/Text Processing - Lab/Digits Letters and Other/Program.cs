using System;

namespace Digits_Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            string digits = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
                else if (char.IsLetter(text[i]))
                {
                    letters += text[i];
                }
                else
                {
                    others += text[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
