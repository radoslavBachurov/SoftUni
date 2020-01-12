using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> listOfCarsWaiting = new Queue<string>(Regex.Split(Console.ReadLine(), @"\s+"));
            Stack<string> listOfCarsServed = new Stack<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Service")
                {
                    if (listOfCarsWaiting.Count > 0)
                    {
                        listOfCarsServed.Push(listOfCarsWaiting.Peek());
                        string servedCar = listOfCarsWaiting.Dequeue();
                        Console.WriteLine($"Vehicle {servedCar} got served.");
                    }
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", listOfCarsServed));
                }
                else
                {
                    string[] commandArr = command.Split("-").ToArray();
                    string carToCheck = commandArr[1];

                    if (listOfCarsWaiting.Contains(carToCheck))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
            }

            if (listOfCarsWaiting.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", listOfCarsWaiting)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", listOfCarsServed)}");

        }
    }
}
