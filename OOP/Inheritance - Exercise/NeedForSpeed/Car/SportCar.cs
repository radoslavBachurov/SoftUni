using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Car
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
           : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 10;
        }

        public new double DefaultFuelConsumption { get; set; }

        public override void Drive(int kilometres)
        {
            double fuelConsumed = kilometres * this.DefaultFuelConsumption;
            this.Fuel -= fuelConsumed;
        }
    }
}
