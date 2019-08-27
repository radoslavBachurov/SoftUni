using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int wordLong = word.Length;
            char[] letters = new char[wordLong];
            string newWord = string.Empty;

            for (int i = 0; i < wordLong; i++)
            {
                letters[i] = word[i];
            }
            for (int i = wordLong-1; i >=0 ; i--)
            {
                newWord += letters[i];
            }
            Console.WriteLine(newWord);
        }
    }
}
