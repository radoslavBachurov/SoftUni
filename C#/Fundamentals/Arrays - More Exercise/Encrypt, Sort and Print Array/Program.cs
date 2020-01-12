using System;
using System.Linq;

namespace Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStrings = int.Parse(Console.ReadLine());
            int countVolwes = 0;
            int countConsonant = 0;
            int sumVowels = 0;
            int sumConsonant = 0;
            int[] sumInput = new int[numberStrings];

            for (int i = 0; i < numberStrings; i++)
            {
                string input = Console.ReadLine();
                countVolwes = 0;
                sumVowels = 0;
                countConsonant = 0;
                sumConsonant = 0;

                foreach (char character in input)
                {
                    if (character.Equals('a') || character.Equals('e') || character.Equals('i') || character.Equals('o') ||
                        character.Equals('u')|| character.Equals('A') || character.Equals('E') || character.Equals('I') || character.Equals('O') ||
                        character.Equals('U'))
                    {
                        countVolwes++;
                        sumVowels += (character*input.Length);
                    }
                    else
                    {
                        countConsonant++;
                        sumConsonant += (character/input.Length);
                    }
                }
                sumInput[i] = sumVowels+ sumConsonant;
            }
            Array.Sort(sumInput);
            for (int r = 0; r < numberStrings; r++)
            {
                Console.WriteLine(sumInput[r]);
            }

        }
    }
}
