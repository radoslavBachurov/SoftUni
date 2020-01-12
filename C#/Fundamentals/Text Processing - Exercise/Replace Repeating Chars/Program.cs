using System;
using System.Collections.Generic;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            List<char> sortedChars = new List<char>();
            char lastChar = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    sortedChars.Add(input[0]);
                    continue;
                }

                if (input[i] != lastChar)
                {
                    sortedChars.Add(input[i]);
                }

                lastChar = input[i];
            }

            Console.WriteLine(string.Join("", sortedChars));
        }
    }
}
