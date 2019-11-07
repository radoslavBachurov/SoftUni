using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Car
{
    public class Car : Vehicle
    {
        public Car(int horsePower,double fuel)
            :base(horsePower,fuel)
        {
            this.DefaultFuelConsumption = 3;
        }

        public new double DefaultFuelConsumption { get; set; }

        public override void Drive(int kilometres)
        {
            double fuelConsumed = kilometres * this.DefaultFuelConsumption;
            this.Fuel -= fuelConsumed;
        }
    }
}
