using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                Regex songValidation = new Regex(@"^[A-Z][a-z'\s]+:[A-Z\s]+$");

                if (songValidation.IsMatch(input))
                {
                    Encryption(input);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void Encryption(string input)
        {
            string[] inputArr = input.Split(":").ToArray();
            int key = inputArr[0].Length;

            string encryptedSong = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'' || input[i] == ' ' || input[i] == '\t')
                {
                    encryptedSong += input[i];
                    continue;
                }
                else if (input[i] == ':')
                {
                    encryptedSong += '@';
                }
                else
                {
                    char encryptedChar = input[i];

                    for (int t = 0; t < key; t++)
                    {
                        if (encryptedChar == 'z')
                        {
                            encryptedChar = 'a';
                            continue;
                        }
                        else if (encryptedChar == 'Z')
                        {
                            encryptedChar = 'A';
                            continue;
                        }
                        encryptedChar += (char)1;
                    }
                    encryptedSong += encryptedChar;
                }
            }

            Console.WriteLine($"Successful encryption: {encryptedSong}");
        }
    }
}
