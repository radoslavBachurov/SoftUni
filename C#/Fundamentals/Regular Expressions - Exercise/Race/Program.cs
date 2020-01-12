using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> partipicant = new Dictionary<string, double>();
            string[] input = Console.ReadLine().Split(", ").ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                partipicant.Add(input[i], 0.0);
            }

            ExtractingNameAndTime(partipicant);

            Printing(partipicant);
        }

        private static void ExtractingNameAndTime(Dictionary<string, double> partipicant)
        {
            string coded = string.Empty;

            while ((coded = Console.ReadLine()) != "end of race")
            {
                Regex extractName = new Regex(@"[A-Za-z]+");
                Regex extractDigits = new Regex(@"\d");

                var name = extractName.Matches(coded);
                string summedName = string.Empty;

                foreach (var item in name)
                {
                    summedName += item.ToString();
                }

                var digits = extractDigits.Matches(coded);
                double sum = 0;

                foreach (var item in digits)
                {
                    double digit = double.Parse(item.ToString());
                    sum += double.Parse(item.ToString());
                }

                if (!partipicant.ContainsKey(summedName))
                {
                    continue;
                }
                else
                {
                    partipicant[summedName] += sum;
                }
            }
        }

        private static void Printing(Dictionary<string, double> partipicant)
        {
            int count = 1;
            foreach (var item in partipicant.OrderByDescending(x => x.Value))
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }

                if (count == 3)
                {
                    break;
                }
                count++;
            }
        }
    }
}
