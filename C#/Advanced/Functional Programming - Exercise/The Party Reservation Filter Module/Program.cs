using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, List<string>, bool> startsWithFilter = (name, filter) =>
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    if (name.StartsWith(filter[i]))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<string, List<string>, bool> endsWithFilter = (name, filter) =>
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    if (name.EndsWith(filter[i]))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<string, List<int>, bool> lengthFilter = (name, filter) =>
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    if (name.Length <= filter[i])
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<string, List<string>, bool> containsFilter = (name, filter) =>
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    if(name.Contains(filter[i]))
                    {
                        return false;
                    }
                }

                return true;
            };

            string[] partyList = Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            List<string> startsWith = new List<string>();
            List<string> endsWith = new List<string>();
            List<int> lenght = new List<int>();
            List<string> contains = new List<string>();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArr = command.Split(";").ToArray();

                if (commandArr[0] == "Add filter")
                {
                    AddingFilters(startsWith, endsWith, lenght, contains, commandArr);
                }
                else if (commandArr[0] == "Remove filter")
                {
                    RemovingFilters(startsWith, endsWith, lenght, contains, commandArr);
                }
            }

            FilterAndPrint(startsWithFilter, endsWithFilter, lengthFilter, containsFilter, partyList, startsWith, endsWith, lenght, contains);
        }

        private static void FilterAndPrint(Func<string, List<string>, bool> startsWithFilter, Func<string, List<string>, bool> endsWithFilter, Func<string, List<int>, bool> lengthFilter, Func<string, List<string>, bool> containsFilter, string[] partyList, List<string> startsWith, List<string> endsWith, List<int> lenght, List<string> contains)
        {
            List<string> filteredList = new List<string>();
            filteredList = partyList.Where(name => startsWithFilter(name, startsWith))
                                    .Where(name => endsWithFilter(name, endsWith))
                                    .Where(name => lengthFilter(name, lenght))
                                    .Where(name => containsFilter(name, contains)).ToList();

            Console.WriteLine(string.Join(" ", filteredList));
        }

        private static void RemovingFilters(List<string> startsWith, List<string> endsWith, List<int> lenght, List<string> contains, string[] commandArr)
        {
            if (commandArr[1] == "Starts with")
            {
                startsWith.Remove(commandArr[2]);
            }
            else if (commandArr[1] == "Ends with")
            {
                endsWith.Remove(commandArr[2]);
            }
            else if (commandArr[1] == "Length")
            {
                lenght.Remove(int.Parse(commandArr[2]));
            }
            else if (commandArr[1] == "Contains")
            {
                contains.Remove(commandArr[2]);
            }
        }

        private static void AddingFilters(List<string> startsWith, List<string> endsWith, List<int> lenght, List<string> contains, string[] commandArr)
        {
            if (commandArr[1] == "Starts with" && !startsWith.Contains(commandArr[2]))
            {
                startsWith.Add(commandArr[2]);
            }
            else if (commandArr[1] == "Ends with" && !endsWith.Contains(commandArr[2]))
            {
                endsWith.Add(commandArr[2]);
            }
            else if (commandArr[1] == "Length" && !lenght.Contains(int.Parse(commandArr[2])))
            {
                lenght.Add(int.Parse(commandArr[2]));
            }
            else if (commandArr[1] == "Contains" && !contains.Contains(commandArr[2]))
            {
                contains.Add(commandArr[2]);
            }
        }
    }
}
