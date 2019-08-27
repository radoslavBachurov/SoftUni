using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Regex validation = new Regex(@"^((\$|%)([A-Z][a-z]{2,})\2):\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");

                if (validation.IsMatch(input))
                {
                    var match = validation.Match(input);

                    string name = match.Groups[3].Value;
                    string decryptedNumbers = string.Empty;

                    for (int t = 4; t < 7; t++)
                    {
                        decryptedNumbers += (char)(int.Parse(match.Groups[t].Value));
                    }

                    string decrypted = $"{name}: {decryptedNumbers}";
                    Console.WriteLine(decrypted);
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
