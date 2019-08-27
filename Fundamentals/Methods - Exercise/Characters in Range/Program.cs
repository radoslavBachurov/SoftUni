using System;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintCharactersBetween(firstChar,secondChar);
        }

        private static void PrintCharactersBetween(char firstChar, char secondChar)
        {
            int startChar = Math.Min(firstChar, secondChar);
            int endChar = Math.Max(firstChar, secondChar);

            for (int i = startChar+1; i < endChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
