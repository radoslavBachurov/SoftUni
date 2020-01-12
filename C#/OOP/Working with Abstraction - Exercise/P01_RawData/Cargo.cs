using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public Cargo(int cargoWeight,string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
        public int cargoWeight { get; private set; }
        public string cargoType { get; private set; }
    }
}
