using System;
using System.Collections.Generic;
using System.Linq;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<int, Pair> numbersAndChars = new Dictionary<int, Pair>();

            SplittingPairs(input, numbersAndChars);
            LetterBefore(numbersAndChars);
            LetterAfter(numbersAndChars);
            Printing(numbersAndChars);

        }

        private static void Printing(Dictionary<int, Pair> numbersAndChars)
        {
            decimal sum = 0;

            foreach (var pair in numbersAndChars)
            {
                sum += pair.Value.Number;
            }

            Console.WriteLine($"{sum:f2}");
        }

        private static void LetterAfter(Dictionary<int, Pair> numbersAndChars)
        {
            foreach (var pair in numbersAndChars)
            {
                char letter = pair.Value.After[0];
                int index = (int)letter % 32;
                decimal number = pair.Value.Number;

                if (pair.Value.After.Any(char.IsUpper))
                {
                    pair.Value.Number = number - index;
                }
                else if (pair.Value.After.Any(char.IsLower))
                {
                    pair.Value.Number = number + index;
                }
            }
        }

        private static void LetterBefore(Dictionary<int, Pair> numbersAndChars)
        {
            foreach (var pair in numbersAndChars)
            {
                char letter = pair.Value.Before[0];
                int index = (int)letter % 32;
                decimal number = pair.Value.Number;

                if (pair.Value.Before.Any(char.IsUpper))
                {
                    pair.Value.Number = number / index;
                }
                else if(pair.Value.Before.Any(char.IsLower))
                {
                    pair.Value.Number = number * index;
                }
            }
        }

        private static void SplittingPairs(string[] input, Dictionary<int, Pair> numbersAndChars)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                string before = current[0].ToString();
                string after = current[current.Length - 1].ToString();
                current = current.Substring(1, current.Length - 2);
                decimal number = decimal.Parse(current);

                Pair newPair = new Pair(before, after, number);
                numbersAndChars.Add(i, newPair);
            }
        }
    }
    class Pair
    {
        public Pair(string before, string after, decimal number)
        {
            Before = before;
            After = after;
            Number = number;
        }
        public string Before { get; set; }
        public string After { get; set; }
        public decimal Number { get; set; }
    }
}


