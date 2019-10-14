using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine newEngine)
        {
            Model = model;
            NewEngine = newEngine;
            Weight = "n/a";
            Color = "n/a";
        }

        public string Model { get; set; }
        public Engine NewEngine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($" {Model}:");
            newSB.AppendLine($"  {NewEngine.Model}:");
            newSB.AppendLine($"    Power: {NewEngine.Power}");
            newSB.AppendLine($"    Displacement: {NewEngine.Displacement}");
            newSB.AppendLine($"    Efficiency: {NewEngine.Efficiency}");
            newSB.AppendLine($"  Weight: {Weight}");
            newSB.Append($"  Color: {Color}");

            return newSB.ToString();
        }
    }
}
