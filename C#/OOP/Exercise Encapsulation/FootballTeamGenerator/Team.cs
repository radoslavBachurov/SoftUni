using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        private List<Player> players { get; set; }

        public IReadOnlyCollection<Player> playersInfo => this.players;

        public int Rating => this.CalculateRating();

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

        private int CalculateRating()
        {
            double rating = this.players.Any() ? this.players.Average(p => p.SkillLevel) : 0;
            return (int)Math.Round(rating);
        }

        public void RemovePlayer(Player toRemove)
        {
            this.players.Remove(toRemove);
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
    }
}
