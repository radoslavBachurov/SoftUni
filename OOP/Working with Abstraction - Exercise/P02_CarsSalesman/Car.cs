using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {

        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public string model { get; private set; }
        public Engine engine { get; private set; }
        public int weight { get; private set; }
        public string color { get; private set; }

        public override string ToString()
        {
            string weight = this.weight == -1 ? "n/a" : this.weight.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.model}:\n");
            sb.Append(this.engine.ToString());
            sb.AppendFormat($"  Weight: {weight}\n");
            sb.AppendFormat($"  Color: {this.color}");

            return sb.ToString();
        }
    }
}
