using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            Func<string, int, bool> wordLenght = (x, y) =>
             {
                 y = lenght;
                 return x.Length <= y;
             };

            Action<string[]> printing = input =>
            {
                string[] sortedInput = input.Where(wordLenght).ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, sortedInput));
            };

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            printing(words);
        }
    }
}
