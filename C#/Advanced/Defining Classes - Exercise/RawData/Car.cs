using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tirePressure1, int tireAge1,
            double tirePressure2, int tireAge2,
            double tirePressure3, int tireAge3,
            double tirePressure4, int tireAge4)
        {
            Model = model;
            CargoType = new Cargo(cargoType, cargoWeight);
            NewEngine = new Engine(engineSpeed, enginePower);

            NewTyres = new Tire(); 

            NewTyres.TiresAge[0] = tireAge1;
            NewTyres.TiresAge[1] = tireAge2;
            NewTyres.TiresAge[2] = tireAge3;
            NewTyres.TiresAge[3] = tireAge4;

            NewTyres.TiresPressure[0] = tirePressure1;
            NewTyres.TiresPressure[1] = tirePressure2;
            NewTyres.TiresPressure[2] = tirePressure3;
            NewTyres.TiresPressure[3] = tirePressure4;
        }
        public string Model { get; set; }
        public Cargo CargoType { get; set; }
        public Engine NewEngine { get; set; }
        public Tire NewTyres { get; set; }
    }
}
