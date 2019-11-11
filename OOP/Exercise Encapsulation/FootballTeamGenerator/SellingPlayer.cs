using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public static class SellingPlayer
    {
        public static void RemovePlayer(List<Team> teams, string[] inputArr)
        {
            string teamName = inputArr[1];
            string player = inputArr[2];

            Team team = teams.Find(x => x.Name == teamName);

            if (team.playersInfo.Any(x => x.Name == player))
            {
                Player toRemove = team.playersInfo.FirstOrDefault(x => x.Name == player);
                team.RemovePlayer(toRemove);
            }
            else
            {
                Console.WriteLine($"Player {player} is not in {teamName} team.");
                throw new ArgumentException();
            }
        }
    }
}
