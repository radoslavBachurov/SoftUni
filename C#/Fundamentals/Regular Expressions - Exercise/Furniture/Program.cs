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
            var furnitureList = new List<string>();
            decimal sum = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Regex validation = new Regex(@">>(?<item>[\sA-Za-z0-9.]+)<<(?<price>\d+(.\d+)?)!(?<quantity>[0-9]*)");

                sum += Extraction(input, furnitureList, validation);
            }

            Printing(furnitureList, sum);
        }

        private static decimal Extraction(string input, List<string> furnitureList, Regex validation)
        {
            decimal sum = 0;
            if (validation.IsMatch(input))
            {
                var match = validation.Match(input);
                string name = match.Groups["item"].Value;
                decimal price = decimal.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);
                sum = price * quantity;
                furnitureList.Add(name);
            }
            return sum;
        }

        private static void Printing(List<string> furnitureList, decimal sum)
        {
            Console.WriteLine("Bought furniture:");


            foreach (var item in furnitureList)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }


    }
}