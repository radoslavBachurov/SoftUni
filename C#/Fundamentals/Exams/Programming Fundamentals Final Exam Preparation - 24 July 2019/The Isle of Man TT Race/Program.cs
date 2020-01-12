using System;
using System.Text.RegularExpressions;

namespace The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                Regex validLenght = new Regex(@"=(?<lenght>\d+)!");
                var match = validLenght.Match(input);
                string lenght = match.Groups["lenght"].ToString();

                string formatedString = @"^([#$%*&])(?<name>[A-Za-z]+)(\1)=(?<geohash>\d+)!!(?<crypted>.{})$";
                int index = formatedString.LastIndexOf('}');
                formatedString = formatedString.Insert(index , lenght);

                Regex validationString = new Regex(formatedString);
                var stringMatch = validationString.Match(input);

                if (stringMatch.Success)
                {
                    string racer = stringMatch.Groups["name"].Value;
                    string geohash = stringMatch.Groups["crypted"].Value;
                    string decrypted = string.Empty;

                    for (int i = 0; i < geohash.Length; i++)
                    {
                        decrypted += (char)(geohash[i] + geohash.Length);
                    }

                    Console.WriteLine($"Coordinates found! {racer} -> {decrypted}");
                    break;
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

            }


        }
    }
}
