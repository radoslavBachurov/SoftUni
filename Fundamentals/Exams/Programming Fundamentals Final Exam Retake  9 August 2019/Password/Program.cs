using System;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Regex validation = new Regex(@"^(.+)>([0-9]{3})[|]([a-z]{3})[|]([A-Z]{3})[|]([^<>]{3})<\1$");

                if(validation.IsMatch(input))
                {
                    string encryptedPassword = string.Empty;
                    Match validPassword = validation.Match(input);

                    for (int t = 2; t < 6; t++)
                    {
                        encryptedPassword += validPassword.Groups[t].ToString(); 
                    }

                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
