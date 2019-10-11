using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, string, List<string>> StartsWithSort = (input, criteria) =>
            {
                List<string> collectedNames = new List<string>();
                for (int i = 0; i < input.Count; i++)
                {
                    int indexOfCriteria = input[i].IndexOf(criteria);

                    if (indexOfCriteria == 0)
                    {
                        collectedNames.Add(input[i]);
                    }
                }
                return collectedNames;
            };

            Func<List<string>, string, List<string>> endsWithSort = (input, criteria) =>
            {
                List<string> collectedNames = new List<string>();
                for (int i = 0; i < input.Count; i++)
                {
                    int indexOfCriteria = input[i].IndexOf(criteria);

                    if (indexOfCriteria == input[i].Length - criteria.Length)
                    {
                        collectedNames.Add(input[i]);
                    }
                }
                return collectedNames;
            };

            Func<List<string>, string, List<string>> lenghtSort = (input, criteria) =>
            {
                List<string> collectedNames = new List<string>();
                int lenght = int.Parse(criteria);
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i].Length == lenght)
                    {
                        collectedNames.Add(input[i]);
                    }
                }
                return collectedNames;
            };

            List<string> listOfGuests = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = commandArr[0];
                string criteria = commandArr[1];
                string stringPart = commandArr[2];

                if (action == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        listOfGuests = RemoveMethod(StartsWithSort, listOfGuests, stringPart);
                    }
                    else if (criteria == "EndsWith")
                    {
                        listOfGuests = RemoveMethod(endsWithSort, listOfGuests, stringPart);
                    }
                    else
                    {
                        listOfGuests = RemoveMethod(lenghtSort, listOfGuests, stringPart);
                    }
                }
                else if (action == "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        listOfGuests = DoubleMethod(StartsWithSort, listOfGuests, stringPart);
                    }
                    else if (criteria == "EndsWith")
                    {
                        listOfGuests = DoubleMethod(endsWithSort, listOfGuests, stringPart);
                    }
                    else
                    {
                        listOfGuests = DoubleMethod(lenghtSort, listOfGuests, stringPart);
                    }
                }
            }

            Printing(listOfGuests);

        }

        private static void Printing(List<string> listOfGuests)
        {
            if (listOfGuests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", listOfGuests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static List<string> RemoveMethod(Func<List<string>, string, List<string>> function, List<string> listOfGuests, string criteriaString)
        {
            List<string> collectedGuests = new List<string>();

            collectedGuests = function(listOfGuests, criteriaString);

            for (int i = 0; i < collectedGuests.Count; i++)
            {
                for (int t = 0; t < listOfGuests.Count; t++)
                {
                    if (collectedGuests[i] == listOfGuests[t])
                    {
                        listOfGuests.Remove(listOfGuests[t]);
                    }
                }
            }

            return listOfGuests;
        }
        static List<string> DoubleMethod(Func<List<string>, string, List<string>> function, List<string> listOfGuests, string criteriaString)
        {
            List<string> collectedGuests = new List<string>();

            collectedGuests = function(listOfGuests, criteriaString);
            collectedGuests = collectedGuests.Distinct().ToList();

            for (int i = 0; i < collectedGuests.Count; i++)
            {
                for (int t = 0; t < listOfGuests.Count; t++)
                {
                    if (collectedGuests[i] == listOfGuests[t])
                    {
                        int index = listOfGuests.IndexOf(collectedGuests[i]);
                        listOfGuests.Insert(index + 1, collectedGuests[i]);
                        t++;
                    }
                }
            }

            return listOfGuests;
        }
    }
}
