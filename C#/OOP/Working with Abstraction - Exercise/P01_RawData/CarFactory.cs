using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class CarFactory
    {
        public CarFactory()
        {
            carCataloque = new List<Car>();
        }

        public List<Car> carCataloque { get; set; }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine newEngine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo newCargo = new Cargo(cargoWeight, cargoType);

            Tire[] tires = new Tire[4];
            int tireCounter = 0;
            for (int i = 5; i <= 12; i += 2)
            {
                Tire newTire = new Tire(double.Parse(parameters[i]), int.Parse(parameters[i + 1]));
                tires[tireCounter] = newTire;
                tireCounter++;
            }

            Car newCar = new Car(model, newCargo, tires, newEngine);
            carCataloque.Add(newCar);
        }
    }
}
