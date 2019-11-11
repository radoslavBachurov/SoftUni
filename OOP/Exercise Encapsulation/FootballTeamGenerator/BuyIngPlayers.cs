using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public static class BuyingPlayers
    {
        public static void AddPlayer(string[] input, List<Team> teams)
        {
            string team = input[1];
            string player = input[2];

            int[] stats = input.Skip(3).Select(int.Parse).ToArray();
            Stats newStats = new Stats(stats[0], stats[1], stats[2], stats[3], stats[4]);
            Player newPlayer = new Player(player, newStats);

            ValidateTeam.TeamValidation(input[1], teams);
            Team toAdd = teams.Find(x => x.Name == team);
            toAdd.AddPlayer(newPlayer);
        }
    }
}
