using System;
using System.Collections.Generic;
using System.Linq;

namespace Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingridient = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            var cocktailFreshness = new Dictionary<string, int>();
            cocktailFreshness.Add("Mimosa", 150);
            cocktailFreshness.Add("Daiquiri", 250);
            cocktailFreshness.Add("Sunshine", 300);
            cocktailFreshness.Add("Mojito", 400);

            var cocktailsReady = new Dictionary<string, int>();
            cocktailsReady.Add("Mimosa", 0);
            cocktailsReady.Add("Daiquiri", 0);
            cocktailsReady.Add("Sunshine", 0);
            cocktailsReady.Add("Mojito", 0);

            while (freshness.Count > 0 && ingridient.Any())
            {
                if (ingridient.Peek() == 0)
                {
                    ingridient.Dequeue();
                    continue;
                }
                else if (CheckingForCocktail(freshness, ingridient, cocktailFreshness))
                {
                    int cocktailToMake = ingridient.Peek() * freshness.Peek();

                    foreach (var cocktail in cocktailFreshness)
                    {
                        if (cocktailToMake == cocktail.Value)
                        {
                            cocktailsReady[cocktail.Key]++;
                        }
                    }

                    ingridient.Dequeue();
                    freshness.Pop();
                    continue;
                }
                else
                {
                    freshness.Pop();
                    ingridient.Enqueue(ingridient.Peek() + 5);
                    ingridient.Dequeue();
                }
            }

            if (ReadyForParty(cocktailsReady))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingridient.Any())
            {
                Console.WriteLine($"Ingredients left: {ingridient.Sum()}");
            }

            foreach (var cocktail in cocktailsReady.OrderBy(x => x.Key))
            {
                if (cocktail.Value != 0)
                {
                    Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
                }
            }
        }

        private static bool ReadyForParty(Dictionary<string, int> cocktailsReady)
        {
            foreach (var cocktail in cocktailsReady)
            {
                if (cocktail.Value == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckingForCocktail(Stack<int> freshness, Queue<int> ingridient, Dictionary<string, int> cocktailFreshness)
        {
            foreach (var cocktail in cocktailFreshness)
            {
                if (ingridient.Peek() * freshness.Peek() == cocktail.Value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
