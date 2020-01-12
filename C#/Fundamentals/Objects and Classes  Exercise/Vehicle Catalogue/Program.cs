using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            VehicleCatalogue Catalogue = new VehicleCatalogue();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split().ToArray();
                if (inputArr[0] == "car")
                {
                    AddingCars(inputArr, Catalogue);
                }
                else if (inputArr[0] == "truck")
                {
                    AddingTrucks(inputArr, Catalogue);
                }

            }
            InfoOfVehicles(Catalogue);

            PrintingAverageHP(Catalogue);

        }

        private static void PrintingAverageHP(VehicleCatalogue Catalogue)
        {
            double averageCars = 0;
            double averageTrucks = 0;

            foreach (var item in Catalogue.Cars)
            {
                averageCars += item.HorsePower;
            }
            if (Catalogue.Cars.Count != 0)
            {
                averageCars /= Catalogue.Cars.Count;
            }
            else
            {
                averageTrucks = 0;
            }
            
            Console.WriteLine($"Cars have average horsepower of: {averageCars:f2}.");

            foreach (var item in Catalogue.Trucks)
            {
                averageTrucks += item.HorsePower;
            }
            if (Catalogue.Trucks.Count != 0)
            {
                averageTrucks /= Catalogue.Trucks.Count;
            }
            else
            {
                averageTrucks = 0;
            }
            
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucks:f2}.");
        }

        private static void InfoOfVehicles(VehicleCatalogue Catalogue)
        {
            string input;
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                if (Catalogue.Cars.Any(x => x.Model == input))
                {
                    Car currentModel = Catalogue.Cars.First(x => x.Model == input);
                    Console.WriteLine("Type: Car");
                    Console.WriteLine($"Model: {currentModel.Model}");
                    Console.WriteLine($"Color: {currentModel.Color}");
                    Console.WriteLine($"Horsepower: {currentModel.HorsePower}");

                }
                else if (Catalogue.Trucks.Any(x => x.Model == input))
                {
                    Truck currentModel = Catalogue.Trucks.First(x => x.Model == input);
                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {currentModel.Model}");
                    Console.WriteLine($"Color: {currentModel.Color}");
                    Console.WriteLine($"Horsepower: {currentModel.HorsePower}");
                }
            }

            
        }

        private static void AddingTrucks(string[] inputArr, VehicleCatalogue catalogue)
        {
            Truck newTruck = new Truck(inputArr[1], inputArr[2], int.Parse(inputArr[3]));
            catalogue.Trucks.Add(newTruck);
        }

        private static void AddingCars(string[] inputArr, VehicleCatalogue catalogue)
        {
            Car newCar = new Car(inputArr[1], inputArr[2], int.Parse(inputArr[3]));
            catalogue.Cars.Add(newCar);
        }
    }
    class Car
    {
        public Car(string model, string color, int horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public Truck(string model, string color, int horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    class VehicleCatalogue
    {
        public VehicleCatalogue()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
