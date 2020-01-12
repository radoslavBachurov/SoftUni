using System;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] tickets = Regex.Split(text, @"\s*[,]+\s*");

            for (int i = 0; i < tickets.Length; i++)
            {
                string currentTicket = tickets[i];
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool Jackpot = true;
                char firstChar = currentTicket[0];

                for (int t = 0; t < tickets[i].Length; t++)
                {
                    if (firstChar != currentTicket[t])
                    {
                        Jackpot = false;
                    }
                }

                if (Jackpot 
                    && (firstChar == '@' || firstChar == '^' || firstChar == '$' || firstChar == '#'))
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - 10{firstChar} Jackpot!");
                    continue;
                }

                string firstPart = currentTicket.Substring(0, 10);
                string secondPart = currentTicket.Substring(10, 10);

                Regex validation = new Regex(@"(?<matchSymbol>[@]{6,}|[#]{6,}|[$]{6,}|[\^]{6,})");
                var firstMatch = validation.Match(firstPart);
                var secondMatch = validation.Match(secondPart);

                string symbolLenghtFirst = firstMatch.Groups["matchSymbol"].Value;
                string symbolLenghtSecond = secondMatch.Groups["matchSymbol"].Value;
                int minLenght = Math.Min(symbolLenghtFirst.Length, symbolLenghtSecond.Length);

                if (validation.IsMatch(firstPart) && validation.IsMatch(secondPart)
                    && symbolLenghtFirst[0] == symbolLenghtSecond[0])
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - {minLenght}{symbolLenghtFirst[0]}");
                    continue;
                }

                Console.WriteLine($"ticket \"{currentTicket}\" - no match");

            }
        }
    }
}
