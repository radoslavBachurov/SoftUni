using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats playerStats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.PlayerStats = stats;
        }

        public Stats PlayerStats
        {
            get { return this.playerStats; }
            private set { this.playerStats = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                    throw new ArgumentException();
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public double SkillLevel => playerStats.OverallSkillLevel;
    }
}
