using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|").ToArray();
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];
            char[] capitalLetters = FirstPartEdit(firstPart);

            var secondPartInfoChars = new List<char>();
            var secondPartInfoLenght = new List<int>();
            var toPrint = new Dictionary<string, char>();

            SecondPartEdit(secondPart, capitalLetters, secondPartInfoChars, secondPartInfoLenght);
            ThirdPartEditing(thirdPart, secondPartInfoChars, secondPartInfoLenght, toPrint);
            Printing(capitalLetters, toPrint);

        }

        private static void Printing(char[] capitalLetters, Dictionary<string, char> toPrint)
        {
            for (int i = 0; i < capitalLetters.Length; i++)
            {
                foreach (var item in toPrint)
                {
                    if (capitalLetters[i] == item.Value)
                    {
                        Console.WriteLine(item.Key);
                    }
                }
            }
        }

        private static void ThirdPartEditing(string thirdPart, List<char> secondPartInfoChars, List<int> secondPartInfoLenght, Dictionary<string, char> toPrint)
        {
            string[] words = thirdPart.Split().ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (secondPartInfoChars.Contains(word[0]))
                {
                    int index = secondPartInfoChars.IndexOf(word[0]);

                    if (secondPartInfoLenght[index] == word.Length - 1)
                    {
                        if(toPrint.ContainsKey(word))
                        {
                            secondPartInfoLenght.RemoveAt(index);
                            secondPartInfoChars.RemoveAt(index);
                            continue;
                        }
                        toPrint.Add(word, word[0]);
                        secondPartInfoLenght.RemoveAt(index);
                        secondPartInfoChars.RemoveAt(index);
                    }
                }
            }
        }

        private static void SecondPartEdit(string secondPart, char[] capitalLetters, List<char> secondPartInfoChars, List<int> secondPartInfoLenght)
        {
            Regex secondValidation = new Regex(@"(\d{2}):(\d{2})");
            var matchTwo = secondValidation.Matches(secondPart);


            foreach (Match item in matchTwo)
            {
                int letter = int.Parse(item.Groups[1].ToString());
                int lenght = int.Parse(item.Groups[2].ToString());

                if (capitalLetters.Contains((char)(letter)) && (lenght > 0 && lenght <= 20))
                {
                    secondPartInfoChars.Add((char)(letter));
                    secondPartInfoLenght.Add(lenght);
                }
            }
        }

        private static char[] FirstPartEdit(string firstPart)
        {
            Regex firstPartValidation = new Regex(@"(#|\$|%|\*|&)([A-Z]+)\1");
            var matchOne = firstPartValidation.Match(firstPart);
            char[] capitalLetters = matchOne.Groups[2].Value.ToCharArray();
            return capitalLetters;
        }
    }
}
