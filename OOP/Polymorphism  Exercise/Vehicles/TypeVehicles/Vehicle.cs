using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.TypeVehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double initialFuelQuantity;

        protected Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.LitersPerKm = litersPerKm;
            this.fuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    throw new Exception($"Cannot fit {value - this.fuelQuantity} fuel in the tank");
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double LitersPerKm { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.LitersPerKm;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
        }
    }
}
