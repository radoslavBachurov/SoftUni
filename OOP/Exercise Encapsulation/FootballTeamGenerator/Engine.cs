using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] inputArr = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (inputArr[0] == "Team")
                    {
                        if (!ValidateTeam(inputArr[1]))
                        {
                            Team newTeam = new Team(inputArr[1]);
                            teams.Add(newTeam);
                        }
                    }

                    else if (inputArr[0] == "Add")
                    {
                        BuyingPlayers.AddPlayer(inputArr, teams);
                    }

                    else if (inputArr[0] == "Remove")
                    {
                        SellingPlayer.RemovePlayer(teams,inputArr);
                        
                    }
                    else if (inputArr[0] == "Rating")
                    {
                        if (ValidateTeam(inputArr[1]))
                        {
                            Team team = teams.Find(x => x.Name == inputArr[1]);
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {inputArr[1]} does not exist.");
                            throw new Exception();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private bool ValidateTeam(string teamName)
        {
            if (teams.Any(x => x.Name == teamName))
            {
                return true;
            }
            return false;
        }
    }
}
