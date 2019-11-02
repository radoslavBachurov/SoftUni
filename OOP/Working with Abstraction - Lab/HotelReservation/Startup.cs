using System;
using System.Linq;

namespace HotelReservation
{
    class Startup
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine($"{PriceCalculator.GetTotalPrice(input):f2}");
        }
    }
}
