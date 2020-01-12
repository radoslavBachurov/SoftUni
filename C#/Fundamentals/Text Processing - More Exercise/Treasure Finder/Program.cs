using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Treasure_Finder
{
    class Program
    {
        private static object regex;

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string text = string.Empty;
            while ((text = Console.ReadLine()) != "find")
            {
                string decrypted = string.Empty;
                for (int i = 0; i < text.Length; i += 0)
                {
                    for (int t = 0; t < numbers.Length; t++, i++)
                    {
                        if (i >= text.Length)
                            break;

                        decrypted += (char)(text[i] - numbers[t]);
                    }
                }

                Regex extraction = new Regex(@"&([A-Za-z]+)&.*?<(.*?)>");
                var match = extraction.Match(decrypted);

                Console.WriteLine($"Found {match.Groups[1].Value} at {match.Groups[2].Value}");
            }
        }
    }
}
