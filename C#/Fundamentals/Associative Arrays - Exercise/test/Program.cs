using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            var sides = new Dictionary<string, List<string>>();

            while (inputLine != "Lumpawaroo")
            {
                if (inputLine.Contains("|"))
                {
                    string[] inputArray = inputLine.Split(" | ").ToArray();

                    string forceSide = inputArray[0];
                    string forceUser = inputArray[1];

                    if (!sides.ContainsKey(forceSide))
                    {
                        if (sides.Any(x => x.Value.Contains(forceUser)))
                            continue;

                        sides.Add(forceSide, new List<string>());
                    }

                    if (!sides[forceSide].Contains(forceUser))
                        sides[forceSide].Add(forceUser);
                }
                else if (inputLine.Contains("->"))
                {
                    string[] inputArray = inputLine.Split(" -> ").ToArray();

                    string forceUser = inputArray[0];
                    string forceSide = inputArray[1];

                    if (sides.ContainsKey(forceSide))
                    {
                        if (sides[forceSide].Contains(forceUser))
                            continue;
                    }

                    foreach (var user in sides)
                        if (user.Value.Contains(forceUser))
                        {
                            user.Value.Remove(forceUser);
                        }

                    if (!sides.ContainsKey(forceSide))
                        sides[forceSide] = new List<string>();

                    sides[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }

                inputLine = Console.ReadLine();
            }

            sides = sides
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in sides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    var usersList = side.Value.OrderBy(x => x).ToList();

                    foreach (var user in usersList)
                        Console.WriteLine($"! {user}");
                }

            }
        }
    }
}