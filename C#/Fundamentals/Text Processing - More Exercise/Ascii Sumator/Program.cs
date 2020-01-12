using System;
using System.Text.RegularExpressions;

namespace Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int firstNumber = Math.Min(first, second);
            int secondNumber = Math.Max(first, second);

            int extractedTextSum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int current = text[i];

                if(current>firstNumber&&current<secondNumber)
                {
                    extractedTextSum += current;
                }
            }

            Console.WriteLine(extractedTextSum);
        }
    }
}
