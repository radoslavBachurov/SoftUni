using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine newEngine,Tire[] newTire)
            : this(make,model,year,fuelQuantity,fuelConsumption)
        {
            Engine = newEngine;
            Tire = newTire;
        }


        public string Make {private get; set; }
        public string Model {private get; set; }
        public int Year {private get; set; }
        public double FuelQuantity { private get; set; }
        public double FuelConsumption { private get; set; }
        public Engine Engine { private get; set; }
        public Tire[] Tire { private get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - distance / 100 * FuelConsumption >= 0)
            {
                FuelQuantity -= FuelConsumption * distance / 100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }
    }
}
