using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.TypeVehicles
{
    public class Bus : Vehicle, IVehicle
    {
        private const double airConditionerFuelIncreasing = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + airConditionerFuelIncreasing, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity += liters;
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (this.LitersPerKm - airConditionerFuelIncreasing);

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }
    }
}
