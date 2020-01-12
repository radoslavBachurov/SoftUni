using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = Path.Combine("Resources", "text.txt");
            string wordsPath = Path.Combine("Resources", "words.txt");

            string text = File.ReadAllText(textPath);
            string words = File.ReadAllText(wordsPath);

            string[] textArr = text.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] wordsArr = words.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, int> matchedWords = new Dictionary<string, int>();

            for (int i = 0; i < wordsArr.Length; i++)
            {
                int count = 1;

                for (int t = 0; t < textArr.Length; t++)
                {
                    if (wordsArr[i] == textArr[t])
                    {
                        count++;
                    }
                }

                if (count > 0 && !matchedWords.ContainsKey(wordsArr[i]))
                {
                    matchedWords.Add(wordsArr[i], count);
                }
            }

            using (var writer = new StreamWriter("output.txt"))
            {
                foreach (var word in matchedWords.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
