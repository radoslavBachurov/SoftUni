using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArr = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(inputArr[0]=="IN")
                {
                    parking.Add(inputArr[1]);
                }
                else
                {
                    if(parking.Contains(inputArr[1]))
                    {
                        parking.Remove(inputArr[1]);
                    }
                }
            }

            if (parking.Count > 0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
