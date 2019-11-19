using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.TypeVehicles
{
    public class Truck : Vehicle, IVehicle
    {
        private const double airConditionerFuelIncreasing = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + airConditionerFuelIncreasing, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);

            if (this.FuelQuantity + liters * 0.95 > this.TankCapacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters * 0.95;
        }
    }
}
