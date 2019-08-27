using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var UsersList = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputArr = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string[] inputInfo = input
                    .Split(new string[] { " | ", " -> " }, StringSplitOptions.None)
                    .ToArray();

                if (inputArr.Contains("|"))
                {
                    AddingUsers(inputInfo, UsersList);
                }

                else if (inputArr.Contains("->"))
                {
                    ChangingUsersSide(inputInfo, UsersList);
                }
            }

            Printing(UsersList);

        }

        private static void Printing(Dictionary<string, List<string>> usersList)
        {
            foreach (var item in usersList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (item.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    foreach (var user in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

        private static void ChangingUsersSide(string[] inputArr, Dictionary<string, List<string>> usersList)
        {
            string forceSide = inputArr[1];
            string forceUser = inputArr[0];


            if (!usersList.ContainsKey(forceSide))
            {
                usersList[forceSide] = new List<string>();
            }

            foreach (var force in usersList)
            {
                if (force.Value.Contains(forceUser))
                {
                    force.Value.Remove(forceUser);
                }
            }

            usersList[forceSide].Add(forceUser);
            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }
        private static void AddingUsers(string[] inputArr, Dictionary<string, List<string>> usersList)
        {
            string forceSide = inputArr[0];
            string forceUser = inputArr[1];
            bool userExists = true;

            foreach (var item in usersList)
            {
                if (item.Value.Contains(forceUser))
                {
                    userExists = false;
                }
            }

            if (userExists)
            {
                if (!usersList.ContainsKey(forceSide))
                {
                    usersList.Add(forceSide, new List<string>());
                }
                usersList[forceSide].Add(forceUser);
            }
        }
    }
}
