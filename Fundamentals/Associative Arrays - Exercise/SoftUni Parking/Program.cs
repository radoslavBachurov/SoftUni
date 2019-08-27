using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingList = new Dictionary<string, string>();

            for (int i = 0; i < countCommands; i++)
            {
                string[] commandArr = Console.ReadLine().Split().ToArray();

                if (commandArr.Contains("register"))
                {
                    RegisterCars(commandArr, parkingList);
                }
                else if (commandArr.Contains("unregister"))
                {
                    UnregisterCars(commandArr, parkingList);
                }
            }

            Printing(parkingList);
        }

        private static void Printing(Dictionary<string, string> parkingList)
        {

            foreach (var item in parkingList)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        
        }

        private static void UnregisterCars(string[] commandArr, Dictionary<string, string> parkingList)
        {
            string username = commandArr[1];

            if(!parkingList.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                parkingList.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
        }

        private static void RegisterCars(string[] commandArr, Dictionary<string, string> parkingList)
        {
            string username = commandArr[1];
            string licence = commandArr[2];

            if (parkingList.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {parkingList[username]}");
            }
            else
            {
                parkingList.Add(username, licence);
                Console.WriteLine($"{username} registered {licence} successfully");
            }
        }
    }
}
