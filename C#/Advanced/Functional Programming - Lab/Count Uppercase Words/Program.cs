using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsWithUpperCase = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word[0] == char.ToUpper(word[0]))
                .ToArray();

            foreach (var word in wordsWithUpperCase)
            {
                Console.WriteLine(word);
            }
        }


    }
}
