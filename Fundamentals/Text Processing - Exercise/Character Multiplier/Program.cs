using System;
using System.Linq;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            string firstWord = words[0];
            string secondWord = words[1];
            double sum = 0;

            int shorter = Math.Min(firstWord.Length, secondWord.Length);
            int longer = Math.Max(firstWord.Length, secondWord.Length);

            for (int i = 0; i < shorter; i++)
            {
                sum += firstWord[i] * secondWord[i];
            }

            for (int i = shorter; i < longer; i++)
            {
                if (firstWord.Length > secondWord.Length)
                {
                    sum += firstWord[i];
                }
                else
                {
                    sum += secondWord[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
