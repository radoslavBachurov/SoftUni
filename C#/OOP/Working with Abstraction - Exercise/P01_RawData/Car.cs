using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model, Cargo cargo, Tire[] tires,Engine engine)
        {
            this.model = model;
            this.newCargo = cargo;
            this.Tires = tires;
            this.Engine = engine;
        }
        public string model { get; private set; }
        public Cargo newCargo { get; set; }
        public Tire[] Tires { get; set; }
        public Engine Engine { get; set; }
    }
}
