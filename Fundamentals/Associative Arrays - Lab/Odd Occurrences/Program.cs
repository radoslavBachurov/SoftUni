using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            var listOfWords = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (listOfWords.ContainsKey(input[i]))
                {
                    listOfWords[input[i]]++;
                }

                else
                {
                    listOfWords[input[i]] = 1;
                }
            }

            var sortedDictionary = listOfWords.Where(x => x.Value % 2 != 0);

            foreach (var item in sortedDictionary)
            {
                Console.Write(item.Key+" ");
            }
        }
    }
}
