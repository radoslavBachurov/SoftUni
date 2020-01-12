using System;
using System.Collections.Generic;

namespace Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<int> take = new List<int>();
            List<int> skip = new List<int>();
            List<char> characters = new List<char>();

            IsLetterOrDigitMethod(text, numbers, characters);
            SplitNumbersList(numbers, skip, take);
            EncryptMessage(take, skip, numbers, characters);
        }

        private static void EncryptMessage(List<int> take, List<int> skip, List<int> numbers, List<char> characters)
        {
            int indexAfterTake = 0;
            int indexAfterSkip = 0;
            int counter = 0;
            string takeStr = string.Empty;
            string skipStr = string.Empty;
            int i;
            int t;

            while (true)
            {
                if (takeStr.Length + skipStr.Length >= characters.Count)
                {
                    break;
                }

                for (i = indexAfterSkip; i < indexAfterSkip + take[counter]; i++)
                {
                    if (i == characters.Count)
                    {
                        break;
                    }
                    takeStr += characters[i].ToString();
                }

                indexAfterTake = i;

                for (t = indexAfterTake; t < indexAfterTake + skip[counter]; t++)
                {
                    if (t == characters.Count)
                    {
                        break;
                    }
                    skipStr += characters[t].ToString();
                }

                indexAfterSkip = t;
                counter++;

                if (counter >= skip.Count)
                {
                    break;
                }
            }
            Console.WriteLine(takeStr);
        }

        private static void SplitNumbersList(List<int> numbers, List<int> skip, List<int> take)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
        }

        private static void IsLetterOrDigitMethod(string text, List<int> numbers, List<char> characters)
        {
            foreach (char letter in text)
            {
                bool isLetter = char.IsLetter(letter);
                bool isDigit = char.IsDigit(letter);
                if (isDigit)
                {
                    numbers.Add(int.Parse(letter.ToString()));
                }
                else
                {
                    characters.Add(letter);
                }
            }
        }
    }
}
