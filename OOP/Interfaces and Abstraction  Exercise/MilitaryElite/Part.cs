using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Part
    {
        public Part(string name, double hours)
        {
            Name = name;
            Hours = hours;
        }

        public string Name { get; private set; }
        public double Hours { get; private set; }

        public override string ToString()
        {
            string toReturn = $"Part Name: {this.Name} Hours Worked: {this.Hours}";
            return toReturn;
        }
    }
}
