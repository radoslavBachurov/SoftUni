using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class Startup
    {
        static void Main(string[] args)
        {
            CarFactory cars = new CarFactory();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                CreatingCars(cars);
            }

            Printing(cars);
        }

        private static void Printing(CarFactory cars)
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars.carCataloque
                    .Where(x => x.newCargo.cargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars.carCataloque
                    .Where(x => x.newCargo.cargoType == "flamable" && x.Engine.enginePower > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void CreatingCars(CarFactory cars)
        {
            string[] parameters = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            cars.Add(parameters);
        }
    }
}
