using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Motorcycle
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }

        public new double DefaultFuelConsumption { get; set; }

        public override void Drive(int kilometres)
        {
            double fuelConsumed = kilometres * this.DefaultFuelConsumption;
            this.Fuel -= fuelConsumed;
        }
    }
}
