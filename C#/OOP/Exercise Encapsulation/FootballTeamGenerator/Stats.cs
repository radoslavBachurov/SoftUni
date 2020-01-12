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
                StatValidator(value, "Endurance");
                this.endurance = value;
            }
        }

        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                StatValidator(value, "Sprint");
                this.sprint = value;
            }
        }

        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                StatValidator(value, "Dribble");
                this.dribble = value;
            }
        }

        private int Passing
        {
            get { return this.passing; }
            set
            {
                StatValidator(value, "Passing");
                this.passing = value;
            }
        }

        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                StatValidator(value, "Shooting");
                this.shooting = value;
            }
        }


        public double OverallSkillLevel => (this.Endurance + this.Dribble +
            this.Shooting + this.Sprint + this.Passing) / 5.0;


        private static void StatValidator(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine($"{stat} should be between 0 and 100.");
                throw new ArgumentException();
            }
        }
    }
}
