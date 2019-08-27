using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characterList = Console.ReadLine()
                .ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray();
                

            Dictionary<char, int> orderedChars = new Dictionary<char, int>();

            for (int i = 0; i < characterList.Length; i++)
            {
                if (orderedChars.ContainsKey(characterList[i]))
                {
                    orderedChars[characterList[i]]++;
                }
                else
                {
                    orderedChars.Add(characterList[i], 1);
                }
            }

            foreach (var item in orderedChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
