using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo(string type,int cargoWeight)
        {
            CargoType = type;
            CargoWeight = cargoWeight;
        }
        public string CargoType { get; set; }
        public int CargoWeight { get; set; }
    }
}
