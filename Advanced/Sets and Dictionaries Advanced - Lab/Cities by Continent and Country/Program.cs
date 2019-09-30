using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var CountryList = new Dictionary<string, Dictionary<string, List<string>>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!CountryList.ContainsKey(continent))
                {
                    CountryList.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!CountryList[continent].ContainsKey(country))
                {
                    CountryList[continent].Add(country, new List<string>());
                }

                CountryList[continent][country].Add(city);

            }

            foreach (var continent in CountryList)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
