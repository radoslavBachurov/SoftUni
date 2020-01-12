using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTeams = int.Parse(Console.ReadLine());
            List<Teams> teams = new List<Teams>();

            CreatingTeams(countTeams, teams);
            AddinMembersToTeams(teams);
            PrintingTeams(teams);
        }

        private static void PrintingTeams(List<Teams> teams)
        {
            List<Teams> disbandTeams = new List<Teams>();
            List<Teams> sortedTeams = new List<Teams>();

            foreach (var item in teams)
            {
                if (item.TeamMembers.Count == 0)
                {
                    disbandTeams.Add(item);
                }
            }

            foreach (var item in teams)
            {
                if (item.TeamMembers.Count > 0)
                {
                    sortedTeams.Add(item);
                }
            }

            sortedTeams = sortedTeams.OrderByDescending(a => a.TeamMembers.Count)
                               .ThenBy(b => b.TeamName).ToList();

            foreach (var item in sortedTeams)
            {
                Console.WriteLine($"{item.TeamName}");
                Console.WriteLine($"- {item.Creator}");

                foreach (var member in item.TeamMembers.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }

            }


            Console.WriteLine($"Teams to disband:");

            if (disbandTeams.Count != 0)
            {
                disbandTeams = disbandTeams.OrderBy(y => y.TeamName).ToList();
                foreach (var item in disbandTeams)
                {
                    Console.WriteLine(item.TeamName);
                }
            }

        }

        private static void AddinMembersToTeams(List<Teams> teams)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] inputArr = input.Split("->").ToArray();
                string member = inputArr[0];
                string team = inputArr[1];

                if (!teams.Any(x => x.TeamName == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Any(x => x.TeamMembers.Contains(member)) || teams.Any(x => x.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    Teams currentTeam = teams.First(x => x.TeamName == team);
                    currentTeam.TeamMembers.Add(member);
                }

            }
        }

        private static void CreatingTeams(int countTeams, List<Teams> teams)
        {
            for (int i = 0; i < countTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-").ToArray();
                string creator = input[0];
                string teamName = input[1];

                Teams team = new Teams(creator, teamName);

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }

                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
        }
    }
    class Teams
    {
        public Teams(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            TeamMembers = new List<string>();
        }
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> TeamMembers { get; set; }
    }
}
