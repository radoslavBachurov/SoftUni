using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var individualStatistics = new Dictionary<string, int>();
            var contestsList = new Dictionary<string, List<Participant>>();

            string input = string.Empty;

            input = AddingContestsAndUsers(individualStatistics, contestsList);
            Printing(individualStatistics, contestsList);
        }

        private static void Printing(Dictionary<string, int> individualStatistics, Dictionary<string, List<Participant>> contestsList)
        {
            int position = 0;
            foreach (var contest in contestsList)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                position = 0;
                foreach (var participant in contest.Value.OrderByDescending(x => x.Points).ThenBy(x => x.Username))
                {
                    position++;
                    Console.WriteLine($"{position}. {participant.Username} <::> {participant.Points}");
                }
            }

            Console.WriteLine("Individual standings:");

            position = 0;
            foreach (var person in individualStatistics.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                position++;
                Console.WriteLine($"{position}. {person.Key} -> {person.Value}");
            }
        }

        private static string AddingContestsAndUsers(Dictionary<string, int> individualStatistics, Dictionary<string, List<Participant>> contestsList)
        {
            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputArr = input.Split(" -> ").ToArray();
                string username = inputArr[0];
                string contest = inputArr[1];
                int points = int.Parse(inputArr[2]);

                if (!individualStatistics.ContainsKey(username))
                {
                    individualStatistics.Add(username, 0);
                }
                if (!contestsList.ContainsKey(contest))
                {
                    Participant newUser = new Participant(username, points);
                    contestsList.Add(contest, new List<Participant>());
                    contestsList[contest].Add(newUser);
                    individualStatistics[username] += points;
                }
                else
                {
                    if (contestsList[contest].Any(x => x.Username == username))
                    {
                        Participant userToCheck = contestsList[contest].Find(x => x.Username == username);

                        if (userToCheck.Points < points)
                        {
                            individualStatistics[username] += (points - userToCheck.Points);
                            userToCheck.Points = points;
                        }
                    }
                    else
                    {
                        Participant newUser = new Participant(username, points);
                        contestsList[contest].Add(newUser);
                        individualStatistics[username] += points;
                    }
                }
            }

            return input;
        }
    }
    class Participant
    {
        public Participant(string username, int points)
        {
            Username = username;
            Points = points;
        }
        public string Username { get; set; }
        public int Points { get; set; }
    }
}
