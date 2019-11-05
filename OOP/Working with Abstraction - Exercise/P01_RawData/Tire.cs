using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Tire
    {
        public Tire(double tirePressure, int tireAge)
        {
            this.Pressure = tirePressure;
            this.Age = tireAge;
        }
        public double Pressure { get; set; }
        public int Age { get; set; }

    }
}
