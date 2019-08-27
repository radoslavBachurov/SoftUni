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
                Regex validator = new Regex($@"^[A-Za-z!@#$?0-9]+=(\d+)<<.+$");

                if (validator.IsMatch(input))
                {
                    string[] inputArr = Regex.Split(input, @"=|<<");
                    int lenght = int.Parse(inputArr[1]);
                    string geohashCode = inputArr[2];

                    if (lenght == geohashCode.Length)
                    {
                        string codedName = inputArr[0];
                        string name = string.Empty;
                        for (int i = 0; i < codedName.Length; i++)
                        {
                            if (char.IsLetterOrDigit(codedName[i]))
                            {
                                name += codedName[i];
                            }
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {geohashCode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
