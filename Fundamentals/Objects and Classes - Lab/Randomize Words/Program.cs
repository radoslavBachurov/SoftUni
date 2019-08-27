using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            RandomWords newOrder = new RandomWords();
            newOrder.AddLists(words);
            newOrder.Roll(newOrder.RandomizedWords);

            for (int i = 0; i <= words.Count - 1; i++)
            {
                Console.WriteLine(newOrder.RandomizedWords[i]);
            }
          
        }
    }
    public class RandomWords
    {

        private List<string> type;

        public List<string> RandomizedWords
        {
            get
            {
                return type;
            }
        }

        public void Roll(List<string> type)
        {
            for (int i = 0; i < 100; i++)
            {
                Random number = new Random();
                int numberInRange = number.Next(0, type.Count - 1);
                type.Insert(numberInRange, type[0]);
                type.RemoveAt(0);

            }
           
        }

        public void AddLists(List<string> input)
        {
            type = input;
        }
    }
}
