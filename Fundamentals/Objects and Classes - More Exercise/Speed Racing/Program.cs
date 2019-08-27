using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            TrackCars trackedCars = new TrackCars();

            AddingCarsToTrack(count, trackedCars);

            DrivingCars(trackedCars);

            Printing(trackedCars);
        }

        private static void Printing(TrackCars trackedCars)
        {
            foreach (var car in trackedCars.TrackedCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }

        private static void DrivingCars(TrackCars trackedCars)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split().ToArray();
                string model = commandArr[1];
                double distance = double.Parse(commandArr[2]);

                trackedCars.CheckingDistance(model, distance);
            }
        }

        private static void AddingCarsToTrack(int count, TrackCars trackedCars)
        {
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumtion = double.Parse(input[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumtion);
                trackedCars.TrackedCars.Add(newCar);
            }
        }
    }
    class TrackCars
    {
        public TrackCars()
        {
            TrackedCars = new List<Car>();
        }
        public List<Car> TrackedCars { get; set; }

        public void CheckingDistance(string model, double distance)
        {
            Car checkedCar = TrackedCars.Find(x => x.Model == model);
            double fuelNeeded = checkedCar.FuelConsumtion * distance;

            if (checkedCar.FuelAmount >= fuelNeeded)
            {
                checkedCar.Distance += distance;
                checkedCar.FuelAmount -= fuelNeeded;
            }

            else if (checkedCar.FuelAmount < fuelNeeded)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

           
        }
    }
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumtion)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumtion = fuelConsumtion;
            Distance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumtion { get; set; }
        public double Distance { get; set; }
    }
}
