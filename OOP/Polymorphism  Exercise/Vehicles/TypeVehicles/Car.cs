using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.TypeVehicles
{
    public class Car : Vehicle, IVehicle
    {
        private const double airConditionerFuelIncreasing = 0.9;

        public Car(double fuelQuantity, double litersPerKm,double tankCapacity)
            : base(fuelQuantity, litersPerKm + airConditionerFuelIncreasing, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity += liters;
        }
    }
}

