using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public static class ValidateTeam
    {
        public static void TeamValidation(string name,List<Team> teams)
        {
            if(!teams.Any(x=>x.Name==name))
            {
                Console.WriteLine($"Team {name} does not exist.");
                throw new Exception();
            }
        }
    }
}
