using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;
            decimal totalSum = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Regex validation = new Regex(@"[%]{1}(?<name>[A-Z][a-z]+)[%][^|$%.]*[<](?<product>\w+)[>][^|$%\.]*[|](?<quantity>[\d]+)[|][^|$%\.]*?(?<price>\d+.\d*)\$");

                if (validation.IsMatch(input))
                {
                    var match = validation.Match(input);
                    string name = (match.Groups["name"].Value).ToString();
                    string productName = (match.Groups["product"].Value).ToString();
                    int quantity = int.Parse((match.Groups["quantity"].Value).ToString());
                    var matchPrice = match.Groups["price"].Value;
                    decimal price = decimal.Parse((match.Groups["price"].Value).ToString());

                    Console.WriteLine($"{name}: {productName} - {(quantity * price):F2}");

                    totalSum += quantity * price;
                }
            }

            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }

}
