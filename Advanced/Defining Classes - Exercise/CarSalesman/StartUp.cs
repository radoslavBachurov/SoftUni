using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> listOfEngines = new List<Engine>();
            List<Car> listOfCars = new List<Car>();

            WritingDownEngines(listOfEngines);
            CreatingCars(listOfEngines, listOfCars);
            Printing(listOfCars);
        }

        private static void Printing(List<Car> listOfCars)
        {
            foreach (var car in listOfCars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void CreatingCars(List<Engine> listOfEngines, List<Car> listOfCars)
        {
            int countTwo = int.Parse(Console.ReadLine());

            for (int i = 0; i < countTwo; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                Engine engine = listOfEngines.Find(x => x.Model == input[1]);
                Car newCar = new Car(model, engine);

                if (input.Length == 3)
                {
                    int a;
                    if (int.TryParse(input[2], out a))
                    {
                        newCar.Weight = input[2];
                    }
                    else
                    {
                        newCar.Color = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    newCar.Weight = input[2];
                    newCar.Color = input[3];
                }

                listOfCars.Add(newCar);
            }
        }

        private static void WritingDownEngines(List<Engine> listOfEngines)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] inputEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = inputEngine[0];
                string power = inputEngine[1];
                Engine newEngine = new Engine(model, power);

                if (inputEngine.Length == 3)
                {
                    int a;
                    if (!int.TryParse(inputEngine[2], out a))
                    {
                        newEngine.Efficiency = inputEngine[2];
                    }
                    else
                    {
                        newEngine.Displacement = inputEngine[2];
                    }
                }
                else if (inputEngine.Length == 4)
                {
                    newEngine.Efficiency = inputEngine[3];
                    newEngine.Displacement = inputEngine[2];
                }

                listOfEngines.Add(newEngine);
            }
        }
    }
}
