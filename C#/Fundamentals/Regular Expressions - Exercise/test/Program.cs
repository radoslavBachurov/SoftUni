using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var furnitureList = new Dictionary<string, decimal>();

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Regex validation = new Regex(@">>(?<item>[\sA-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>[0-9]*)");

                Extraction(input, furnitureList, validation);
            }

            Printing(furnitureList);
        }

        private static void Extraction(string input, Dictionary<string, decimal> furnitureList, Regex validation)
        {
            if (validation.IsMatch(input))
            {
                var match = validation.Match(input);
                string name = match.Groups["item"].Value;
                decimal price = decimal.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);
                decimal sumPriceItem = price * quantity;

                if(furnitureList.ContainsKey(name))
                {
                    furnitureList[name] += sumPriceItem;
                }
                else
                {
                    furnitureList.Add(name, sumPriceItem);
                }
            }
        }

        private static void Printing(Dictionary<string, decimal> furnitureList)
        {
            Console.WriteLine("Bought furniture:");
            decimal sum = 0;

            foreach (var item in furnitureList)
            {
                Console.WriteLine($"{item.Key}");
                sum += item.Value;
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }


    }
}