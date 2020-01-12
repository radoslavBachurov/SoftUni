using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> trackOfCars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = inputArr[0];
                double fuelAmount = double.Parse(inputArr[1]);
                double fuelComp = double.Parse(inputArr[2]);

                Car newCar = new Car(model, fuelAmount, fuelComp);
                trackOfCars.Add(newCar);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = commandArr[1];
                double distance = double.Parse(commandArr[2]);

                Car currentCar = trackOfCars.Find(x => x.Model == model);
                currentCar.Drive(distance);
            }

            foreach (var car in trackOfCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
