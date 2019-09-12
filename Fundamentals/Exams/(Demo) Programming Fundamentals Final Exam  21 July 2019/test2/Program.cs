using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook_MoreExe
{
    class Program
    {
        static void Main(string[] args)
        {
            var membersDict = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                var inputInList = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var inputInList2 = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (inputInList.Count == 2)
                {
                    string forceSide = inputInList[0];
                    string forceUser = inputInList[1];
                    if (membersDict.ContainsKey(forceSide))
                    {
                        if (!membersDict.Values.SelectMany(m => m).Any(name => name == forceUser))
                        {
                            membersDict[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {

                        membersDict[forceSide] = new List<string>();
                        if (!membersDict.Values.SelectMany(m => m).Any(name => name == forceUser))
                        {
                            membersDict[forceSide].Add(forceUser);
                        }

                    }

                }
                if (inputInList2.Count == 2)
                {

                    string forceUser = inputInList2[0];
                    string forceSide = inputInList2[1];

                    if (!membersDict.ContainsKey(forceSide))
                    {
                        membersDict[forceSide] = new List<string>();
                    }

                    foreach (var sides in membersDict)
                    {
                        if (sides.Value.Contains(forceUser))
                        {
                            sides.Value.Remove(forceUser);


                        }
                    }
                    membersDict[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }
                foreach (var item in membersDict.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key))
                {
                    if (item.Value.Count > 0)
                    {
                        item.Value.Sort();
                        Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                        foreach (var name in item.Value)
                        {
                            Console.WriteLine($"! {name}");
                        }
                    }
                }


            }
        }
    }
}
