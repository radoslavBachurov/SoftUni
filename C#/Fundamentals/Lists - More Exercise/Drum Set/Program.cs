using System;
using System.Collections.Generic;
using System.Linq;

namespace Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> initialQuality = new List<int>();
            string command = string.Empty;

            for (int i = 0; i < drumSet.Count; i++)
            {
                initialQuality.Add(drumSet[i]);
            }

            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        savings = ReplacingDrums(i, drumSet, initialQuality, savings);
                    }
                }
            }

            PrintingConditionOfDrumSet(drumSet, savings);

        }

        private static void PrintingConditionOfDrumSet(List<int> drumSet, decimal savings)
        {
            foreach (var item in drumSet)
            {
                if (item > 0)
                {
                    Console.Write(item + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }

        private static decimal ReplacingDrums(int indexForReplacement, List<int> drumSet, List<int> initialQuality, decimal savings)
        {
            int priceOfDrum = initialQuality[indexForReplacement] * 3;

            if (priceOfDrum > savings)
            {
                drumSet[indexForReplacement] = 0;
                return savings;
            }
            else
            {
                drumSet[indexForReplacement] = initialQuality[indexForReplacement];
                return savings -= priceOfDrum;
            }
        }
    }
}
