using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        private int Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.endurance = value;
                }
                else
                {
                    Console.WriteLine("Endurance should be between 0 and 100.");
                    throw new ArgumentException();
                }
            }
        }

        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.sprint = value;
                }
                else
                {
                    Console.WriteLine("Sprint should be between 0 and 100.");
                    throw new ArgumentException();
                }
            }
        }

        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.dribble = value;
                }
                else
                {
                    Console.WriteLine("Dribble should be between 0 and 100.");
                    throw new ArgumentException();
                }
            }
        }

        private int Passing
        {
            get { return this.passing; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.passing = value;
                }
                else
                {
                    Console.WriteLine("Passing should be between 0 and 100.");
                    throw new ArgumentException();
                }
            }
        }

        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.shooting = value;
                }
                else
                {
                    Console.WriteLine("Shooting should be between 0 and 100.");
                    throw new ArgumentException();
                }
            }
        }

        public double OverallSkillLevel => (this.Endurance + this.Dribble +
            this.Shooting + this.Sprint + this.Passing) / 5.0;
    }
}
