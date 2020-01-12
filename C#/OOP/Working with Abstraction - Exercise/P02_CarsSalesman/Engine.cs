using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
            : this(model, power, -1, "n/a")
        {
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string model { get; private set; }
        public int power { get; private set; }
        public int displacement { get; private set; }
        public string efficiency { get; private set; }

        public override string ToString()
        {
            string displacementString = this.displacement == -1 ? "n/a" : this.displacement.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"  {this.model}:\n");
            sb.AppendFormat($"    Power: {this.power}\n");
            sb.AppendFormat($"    Displacement: {displacementString}\n");
            sb.AppendFormat($"    Efficiency: {this.efficiency}\n");

            return sb.ToString();
        }
    }
}
