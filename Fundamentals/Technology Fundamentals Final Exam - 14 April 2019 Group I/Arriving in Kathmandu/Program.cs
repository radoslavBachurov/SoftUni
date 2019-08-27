using System;
using System.Text.RegularExpressions;

namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Last note")
            {
                Regex lenghtExtract = new Regex(@"=(\d+)<<");

                if (!lenghtExtract.IsMatch(input))
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                var match = lenghtExtract.Match(input);
                int lenght = int.Parse(match.Groups[1].Value);

                Regex validator = new Regex($@"^[A-Za-z!@#$?0-9]+=(\d+)<<.{{{lenght}}}$");

                if (validator.IsMatch(input))
                {
                    string[] inputArr = Regex.Split(input, @"=|<<");

                    string codedName = inputArr[0];
                    string name = string.Empty;
                    for (int i = 0; i < codedName.Length; i++)
                    {
                        if (char.IsLetterOrDigit(codedName[i])) 
                        {
                            name += codedName[i];
                        }
                    }

                    Console.WriteLine($"Coordinates found! {name} -> {inputArr[2]}");
                }

                else
                {
                    Console.WriteLine("Nothing found!");
                }
                

            }
        }
    }
}
