using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> listOfCryptedMessages = new List<string>();
            var listOfValidPlanets = new Dictionary<string, char>();

            for (int i = 0; i < count; i++)
            {
                string cryptedMessage = Console.ReadLine();
                cryptedMessage = DecryptStarEnigma(cryptedMessage);
                listOfCryptedMessages.Add(cryptedMessage);
            }

            DecryptingAndValidation(listOfCryptedMessages, listOfValidPlanets);

            Printing(listOfValidPlanets);
        }

        private static void Printing(Dictionary<string, char> listOfValidPlanets)
        {
            List<string> atackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            foreach (var item in listOfValidPlanets)
            {
                if (item.Value == 'A')
                {
                    atackedPlanets.Add(item.Key);
                }
                else
                {
                    destroyedPlanets.Add(item.Key);
                }
            }

            atackedPlanets = atackedPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            Console.WriteLine($"Attacked planets: {atackedPlanets.Count}");
            for (int i = 0; i < atackedPlanets.Count; i++)
            {
                Console.WriteLine($"-> {atackedPlanets[i]}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            for (int i = 0; i < destroyedPlanets.Count; i++)
            {
                Console.WriteLine($"-> {destroyedPlanets[i]}");
            }
        }

        private static void DecryptingAndValidation(List<string> listOfCryptedMessages, Dictionary<string, char> listOfValidPlanets)
        {
            Regex validationPlanets = new Regex(@"[@](?<planetName>[A-Za-z]+)[^@\-!:>]*[:](?<population>[0-9]+)[^@\-!:>]*[!](?<atackType>[A|D])[!][^@\-!:>]*[-][>](?<soldierCount>[0-9]+)");

            for (int i = 0; i < listOfCryptedMessages.Count; i++)
            {
                if (validationPlanets.IsMatch(listOfCryptedMessages[i]))
                {
                    var match = validationPlanets.Match(listOfCryptedMessages[i]);
                    string planet = match.Groups["planetName"].Value.ToString();
                    char typeAtack = match.Groups["atackType"].Value.ToString()[0];
                    listOfValidPlanets.Add(planet, typeAtack);
                }
            }
        }

        private static string DecryptStarEnigma(string cryptedMessage)
        {
            Regex starDecrypt = new Regex(@"[STARstar]");
            var matches = starDecrypt.Matches(cryptedMessage);
            int decreaseNumber = matches.Count;
            char[] cryptedMessageArr = cryptedMessage.ToCharArray();

            for (int i = 0; i < cryptedMessage.Length; i++)
            {
                cryptedMessageArr[i] -= (char)decreaseNumber;
            }

            cryptedMessage = string.Join("", cryptedMessageArr);
            return cryptedMessage;
        }
    }
}
