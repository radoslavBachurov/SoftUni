﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
            Displacement = "n/a";
            Efficiency = "n/a";
        }
       
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
