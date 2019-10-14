using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public Tire()
        {
            TiresAge = new double[4];
            TiresPressure = new double[4];
        }
        public double[] TiresAge { get; set; }
        public double[] TiresPressure { get; set; }
    }
}
