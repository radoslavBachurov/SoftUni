using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int countNights = int.Parse(Console.ReadLine());
            int pricePerNight = 0;

            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23":
                            pricePerNight = 30;
                            break;
                        case "24-27":
                            pricePerNight = 35;
                            break;
                        case "28-31":
                            pricePerNight = 40;
                            break;
                    }
                    break;
                case "Italy":
                    switch (dates)
                    {
                        case "21-23":
                            pricePerNight = 28;
                            break;
                        case "24-27":
                            pricePerNight = 32;
                            break;
                        case "28-31":
                            pricePerNight = 39;
                            break;
                    }
                    break;
                case "Germany":
                    switch (dates)
                    {
                        case "21-23":
                            pricePerNight = 32;
                            break;
                        case "24-27":
                            pricePerNight = 37;
                            break;
                        case "28-31":
                            pricePerNight = 43;
                            break;
                    }
                    break;
            }
            double pricePerTrip = countNights * pricePerNight;
            Console.WriteLine($"Easter trip to {destination} : {pricePerTrip:f2} leva.");
        }
    }
}
