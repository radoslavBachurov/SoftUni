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
                    string[] inputArr = input
                        .Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (inputArr[0] == "Team")
                    {
                        Team newTeam = new Team(inputArr[1]);
                        teams.Add(newTeam);
                    }

                    else if (inputArr[0] == "Add")
                    {
                        ValidateTeam.TeamValidation(inputArr[1], teams);
                        BuyingPlayers.AddPlayer(inputArr, teams);
                    }

                    else if (inputArr[0] == "Remove")
                    {
                        ValidateTeam.TeamValidation(inputArr[1], teams);
                        SellingPlayer.RemovePlayer(teams, inputArr);
                    }

                    else if (inputArr[0] == "Rating")
                    {
                        ValidateTeam.TeamValidation(inputArr[1], teams);
                        Team team = teams.Find(x => x.Name == inputArr[1]);
                        Console.WriteLine($"{team.Name} - {team.Rating}");

                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
