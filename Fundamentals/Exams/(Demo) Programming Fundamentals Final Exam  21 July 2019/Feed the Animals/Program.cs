using System;
using System.Collections.Generic;
using System.Linq;

namespace Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> areaAnimalsCount = new Dictionary<string, int>();
            Dictionary<string, double> animalDailyFood = new Dictionary<string, double>();

            string input;
            while ((input = Console.ReadLine()) != "Last Info")
            {
                string[] inputArr = input.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArr[0] == "Add")
                {
                    AddCommand(areaAnimalsCount, animalDailyFood, inputArr);
                }
                else if (inputArr[0] == "Feed")
                {
                    FeedCommand(areaAnimalsCount, animalDailyFood, inputArr);
                }
            }

            Printing(areaAnimalsCount, animalDailyFood);
        }

        private static void Printing(Dictionary<string, int> areaAnimalsCount, Dictionary<string, double> animalDailyFood)
        {
            Console.WriteLine("Animals:");

            foreach (var animal in animalDailyFood.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in areaAnimalsCount.OrderByDescending(x => x.Value))
            {
                if (area.Value <= 0)
                {
                    continue;
                }

                Console.WriteLine($"{area.Key} : {area.Value}");
            }
        }

        private static void FeedCommand(Dictionary<string, int> areaAnimalsCount, Dictionary<string, double> animalDailyFood, string[] inputArr)
        {
            string animalName = inputArr[1];
            double food = double.Parse(inputArr[2]);
            string area = inputArr[3];

            if (animalDailyFood.ContainsKey(animalName))
            {
                animalDailyFood[animalName] -= food;

                if (animalDailyFood[animalName] <= 0)
                {
                    animalDailyFood.Remove(animalName);
                    areaAnimalsCount[area]--;
                    Console.WriteLine($"{animalName} was successfully fed");
                }
            }
        }

        private static void AddCommand(Dictionary<string, int> areaAnimalsCount, Dictionary<string, double> animalDailyFood, string[] inputArr)
        {
            string animalName = inputArr[1];
            double dailyFood = double.Parse(inputArr[2]);
            string area = inputArr[3];

            if (!animalDailyFood.ContainsKey(animalName))
            {
                animalDailyFood.Add(animalName, dailyFood);

                if (!areaAnimalsCount.ContainsKey(area))
                {
                    areaAnimalsCount.Add(area, 1);
                }
                else
                {
                    areaAnimalsCount[area]++;
                }
            }

            else
            {
                animalDailyFood[animalName] += dailyFood;
            }
        }
    }

}
