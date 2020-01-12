using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();

            AddingCars(numberCars, listOfCars);

            SortinAndPrinting(listOfCars);
        }

        private static void SortinAndPrinting(List<Car> listOfCars)
        {
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in listOfCars.Where(x => x.NewCargo.Type == "fragile")
                                              .Where(x => x.NewCargo.Weight < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in listOfCars.Where(x => x.NewCargo.Type == "flamable")
                                              .Where(x => x.NewEngine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }

        private static void AddingCars(int numberCars, List<Car> listOfCars)
        {
            for (int i = 0; i < numberCars; i++)
            {
                string[] inputArr = Console.ReadLine().Split().ToArray();
                Car newCar = new Car(inputArr[0], int.Parse(inputArr[1]), int.Parse(inputArr[2]),
                                     int.Parse(inputArr[3]), inputArr[4]);
                listOfCars.Add(newCar);
            }
        }
    }
    class Car
    {
        public Car(string model, int speed, int power, int weight, string type)
        {
            Model = model;
            NewEngine = new Engine(speed, power);
            NewCargo = new Cargo(weight, type);
        }
        public string Model { get; set; }
        public Engine NewEngine { get; set; }
        public Cargo NewCargo { get; set; }

    }
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
    }
    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
