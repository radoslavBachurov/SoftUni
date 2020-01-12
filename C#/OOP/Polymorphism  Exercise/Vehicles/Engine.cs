using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.TypeVehicles;
namespace Vehicles
{
    public class Engine
    {
        private Car newCar;
        private Truck newTruck;
        private Bus newBus;

        public void Run()
        {

            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            this.newCar = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            this.newTruck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            this.newBus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (input[0] == "Drive")
                    {
                        Driving(input);
                    }
                    else if (input[0] == "Refuel")
                    {
                        Refueling(input);
                    }
                    else if (input[0] == "DriveEmpty")
                    {
                        Console.WriteLine(this.newBus.DriveEmpty(double.Parse(input[2])));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Printing();
        }

        private void Refueling(string[] input)
        {
            if (input[1] == "Car")
            {
                this.newCar.Refuel(double.Parse(input[2]));
            }
            else if (input[1] == "Truck")
            {
                this.newTruck.Refuel(double.Parse(input[2]));
            }
            else if (input[1] == "Bus")
            {
                this.newBus.Refuel(double.Parse(input[2]));
            }
        }

        private void Driving(string[] input)
        {
            if (input[1] == "Car")
            {
                Console.WriteLine(this.newCar.Drive(double.Parse(input[2])));
            }
            else if (input[1] == "Truck")
            {
                Console.WriteLine(this.newTruck.Drive(double.Parse(input[2])));
            }
            else if (input[1] == "Bus")
            {
                Console.WriteLine(this.newBus.Drive(double.Parse(input[2])));
            }
        }

        private void Printing()
        {
            Console.WriteLine($"Car: {this.newCar.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {this.newTruck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {this.newBus.FuelQuantity:f2}");
        }
    }
}
