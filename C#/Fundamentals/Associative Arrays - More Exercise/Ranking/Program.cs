using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> listOfContests = new Dictionary<string, string>();
            Dictionary<string, UserInfo> finalList = new Dictionary<string, UserInfo>();

            AddingContests(listOfContests);

            AddingUsersAndContests(listOfContests, finalList);

            Printing(finalList);
        }

        private static void Printing(Dictionary<string, UserInfo> finalList)
        {
            foreach (var user in finalList.OrderByDescending(x => x.Value.totalPoints))
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.totalPoints} points.");
                break;
            }

            Console.WriteLine("Ranking:");

            foreach (var student in finalList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var contest in student.Value.contestsPoints.OrderByDescending(x => x.Points))
                {
                    Console.WriteLine($"#  {contest.Contest} -> {contest.Points}");
                }
            }
        }

        private static void AddingUsersAndContests(Dictionary<string, string> listOfContests, Dictionary<string, UserInfo> finalList)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArr = input.Split("=>").ToArray();
                string contest = inputArr[0];
                string password = inputArr[1];
                string username = inputArr[2];
                double points = double.Parse(inputArr[3]);

                if (listOfContests.ContainsKey(contest) && listOfContests[contest] == password)
                {
                    UserInfo contestantInfo = new UserInfo();

                    if (!finalList.ContainsKey(username))
                    {
                        ContestPoints userContestPoints = new ContestPoints(contest, points);
                        contestantInfo.contestsPoints.Add(userContestPoints);
                        finalList.Add(username, contestantInfo);
                        finalList[username].totalPoints = points;
                    }
                    else
                    {
                        if (finalList[username].contestsPoints.Any(x => x.Contest == contest))
                        {
                            ContestPoints infoToChange = finalList[username].contestsPoints.Find(x => x.Contest == contest);
                            if (infoToChange.Points < points)
                            {
                                double difference = points - infoToChange.Points;
                                infoToChange.Points = points;
                                finalList[username].totalPoints += difference;
                            }
                        }
                        else if (!finalList[username].contestsPoints.Any(x => x.Contest == contest))
                        {
                            ContestPoints userContestPoints = new ContestPoints(contest, points);
                            finalList[username].contestsPoints.Add(userContestPoints);
                            finalList[username].totalPoints += points;
                        }
                    }
                }
            }
        }

        private static void AddingContests(Dictionary<string, string> listOfContests)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArr = input.Split(":").ToArray();
                listOfContests.Add(inputArr[0], inputArr[1]);
            }
        }
    }
    class UserInfo
    {
        public UserInfo()
        {
            contestsPoints = new List<ContestPoints>();
            totalPoints = 0;
        }
        public List<ContestPoints> contestsPoints { get; set; }
        public double totalPoints { get; set; }
    }
    class ContestPoints
    {
        public ContestPoints(string contest, double points)
        {
            Contest = contest;
            Points = points;
        }
        public string Contest { get; set; }
        public double Points { get; set; }
    }
}
