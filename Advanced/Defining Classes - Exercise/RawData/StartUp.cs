using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> ListOfCars = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double pressure1 = double.Parse(input[5]);
                int age1 = int.Parse(input[6]);
                double pressure2 = double.Parse(input[7]);
                int age2 = int.Parse(input[8]);
                double pressure3 = double.Parse(input[9]);
                int age3 = int.Parse(input[10]);
                double pressure4 = double.Parse(input[11]);
                int age4 = int.Parse(input[12]);

                Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, pressure1, age1,
                    pressure2, age2, pressure3, age3, pressure4, age4);
                ListOfCars.Add(newCar);
            }

            string criteria = Console.ReadLine();

            foreach (var car in ListOfCars)
            {
                if (criteria == "fragile" && (car.NewTyres.TiresPressure[0] < 1 ||
                   car.NewTyres.TiresPressure[1] < 1 ||
                   car.NewTyres.TiresPressure[2] < 1 ||
                   car.NewTyres.TiresPressure[3] < 1))
                {
                    Console.WriteLine($"{car.Model}");
                }

                else if (criteria == "flamable" && car.NewEngine.Power > 250)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}
