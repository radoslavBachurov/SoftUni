using System;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Regex validator = new Regex(@"(\*|@)([A-Z][a-z]{2,})\1:\s\[([A-Za-z]{1})\]\|\[([A-Za-z]{1})\]\|\[([A-Za-z]{1})\]\|$");

                if (validator.IsMatch(input))
                {
                    var match = validator.Match(input);
                    int firstNumber = (char.Parse(match.Groups[3].Value));
                    int secondNumber = (char.Parse(match.Groups[4].Value));
                    int thirdNumber = (char.Parse(match.Groups[5].Value));
                    string toPrint = $"{match.Groups[2].Value}: {firstNumber} {secondNumber} {thirdNumber}";

                    Console.WriteLine(toPrint);
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
