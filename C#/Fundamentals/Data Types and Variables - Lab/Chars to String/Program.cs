using System;

namespace Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char character = char.Parse(Console.ReadLine());
                word += character;
            }
            Console.WriteLine(word);
        }
    }
}
