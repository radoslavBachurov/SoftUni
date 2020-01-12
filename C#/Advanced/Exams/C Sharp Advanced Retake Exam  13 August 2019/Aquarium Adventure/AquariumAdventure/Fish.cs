using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"Fish: {this.Name}");
            newSB.AppendLine($"Color: {this.Color}");
            newSB.Append($"Number of fins: {this.Fins}");
            return newSB.ToString();
        }
    }
}
