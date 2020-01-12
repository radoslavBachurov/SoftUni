using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string name,int level)
        {
            this.Username = name;
            this.Level = level;
        }

        public int Level { get; set; }
        public string Username { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }

   
}
