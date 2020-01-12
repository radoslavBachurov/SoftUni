using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToLower();

            int countVowels = GetVowelsCount(str);
            Console.WriteLine(countVowels);
        }

        private static int GetVowelsCount(string str)
        {
            int vowelCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char currChar = str[i];

                switch (currChar)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        vowelCount++;
                        break;
                }
            }
            return vowelCount;
        }
    }
}
