using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Catalogue Vehicle = new Catalogue();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArr = input.Split("/").ToArray();

                if (inputArr.Contains("Car"))
                {
                    Car newCar = new Car(inputArr[0], inputArr[1], inputArr[2], int.Parse(inputArr[3]));
                    Vehicle.Cars.Add(newCar);
                }
                if (inputArr.Contains("Truck"))
                {
                    Truck newTruck = new Truck(inputArr[0], inputArr[1], inputArr[2], int.Parse(inputArr[3]));
                    Vehicle.Trucks.Add(newTruck);
                }
            }
            
            Printing(Vehicle);
            
        }

        private static void Printing(Catalogue Vehicle)
        {
            if (Vehicle.Cars.Count > 0)
            {
                
                Console.WriteLine("Cars:");
                foreach (var car in Vehicle.Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                    
                }
 }

            if (Vehicle.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in Vehicle.Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
    class Truck
    {
        public Truck(string type, string brand, string model, double weight)
        {
            this.Type = type;
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
        public Car(string type, string brand, string model, double horsePower)
        {
            this.Type = type;
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }
    class Catalogue
    {
        public Catalogue()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

       
    }
}
