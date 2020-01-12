using System;
using System.Linq;
using System.Collections.Generic;

namespace VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            var gamePrice = new Dictionary<string, double>();
            string currentGame = string.Empty;
            var isThereDLC = false;
            var gameDLC = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < input.Length; i++)
            {
                string currentInput = input[i];
                if (currentInput.Contains("-"))
                {
                    string[] gameArgs = currentInput.Split("-");
                    currentGame = gameArgs[0];
                    double currentPrice = double.Parse(gameArgs[1]);
                    // currentPrice -= currentPrice * 0.2;
                    if (!gamePrice.ContainsKey(currentGame))
                    {
                        gamePrice.Add(currentGame, currentPrice);
                    }
                }
                else if (currentInput.Contains(":"))
                {
                    string[] gameArgs = currentInput.Split(":");
                    currentGame = gameArgs[0];
                    string dlcName = gameArgs[1];
                    if (gamePrice.ContainsKey(currentGame))
                    {
                        double currentPrice = gamePrice[currentGame];
                        gameDLC.Add(currentGame, new Dictionary<string, double>());
                        gameDLC[currentGame].Add(dlcName, currentPrice += currentPrice * 0.2);
                        gamePrice.Remove(currentGame);
                    }
                }
            }

            foreach (var item in gamePrice)
            {
                item.Value=
            }

            foreach (var dlc in gameDLC)
            {
                Console.Write($"{dlc.Key} - ");
                foreach (var item in dlc.Value)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}