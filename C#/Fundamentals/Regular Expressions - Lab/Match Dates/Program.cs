using System;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex dateValidator = 
                new Regex(@"\b(?<Day>[0-9]{2})(\.|-|\/)(?<Month>[A-Z][a-z]{2})\1(?<Year>[0-9]{4})\b");
            var matches = dateValidator.Matches(text);

            //Day: 13, Month: Jul, Year: 1928
            foreach (Match item in matches)
            {
                Console.WriteLine($"Day: {item.Groups["Day"].Value}, Month: {item.Groups["Month"].Value}, Year: {item.Groups["Year"].Value}");
            }
        }
    }
}
