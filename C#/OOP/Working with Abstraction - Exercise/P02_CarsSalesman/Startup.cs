using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class Startup
    {
        static void Main(string[] args)
        {
            EngineFactory newEngineFactory = new EngineFactory();
            CarFactory newCarFactory = new CarFactory();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                newEngineFactory.Add(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                newCarFactory.Add(parameters, newEngineFactory);
            }
            
            Printing(newCarFactory);
        }

        private static void Printing(CarFactory newCarFactory)
        {
            foreach (var car in newCarFactory.cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
