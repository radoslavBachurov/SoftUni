using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            ListOfCars = new List<Car>();
            Count = 0;
            this.capacity = capacity;
        }
        public List<Car> ListOfCars { get; set; }
        public int Count { get; private set; }

        public string AddCar(Car car)
        {
            if (ListOfCars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (ListOfCars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            ListOfCars.Add(car);
            Count = ListOfCars.Count;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            if (!ListOfCars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carForRemove = ListOfCars.Find(x => x.RegistrationNumber == registrationNumber);
                ListOfCars.Remove(carForRemove);
                Count = ListOfCars.Count;
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car carToGet = ListOfCars.Find(x => x.RegistrationNumber == registrationNumber);
            return carToGet;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regPlate in registrationNumbers)
            {
                if (ListOfCars.Any(x => x.RegistrationNumber == regPlate))
                {
                    Car car = ListOfCars.Find(x => x.RegistrationNumber == regPlate);
                    ListOfCars.Remove(car);
                }
            }
            Count = ListOfCars.Count;
        }


    }
}
