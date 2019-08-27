using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string text = Console.ReadLine();

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                int numberLenght = numbers[i].Length;
                int number = int.Parse(numbers[i]);

                for (int t = 0; t < numberLenght; t++)
                {
                    sum += number % 10;
                    number /= 10;
                }

                text = FindingLetterWithNumber(sum, text);
            }
        }

        private static string FindingLetterWithNumber(int sum, string text)
        {
            int counterCycles = 0;
            int indexOfLetter = 0;

            for (int i = 0; i <= sum; i++)
            {
                char letter = text[i];

                if (counterCycles == sum)
                {
                    Console.Write(letter);
                    indexOfLetter = i;
                    return text = GenerateNewText(indexOfLetter, text);
                }
                if (i == text.Length - 1)
                {
                    i = -1;
                }
                counterCycles++;
            }
            return text;
        }

        private static string GenerateNewText(int indexOfLetter, string text)
        {
            string newText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if(indexOfLetter==i)
                {
                    continue;
                }
                newText += text[i].ToString();
            }
            return newText;
        }
    }
}
