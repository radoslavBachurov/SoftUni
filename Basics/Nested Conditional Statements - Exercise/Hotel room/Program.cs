using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            
            double studio = 0;
            double apartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    {
                        studio = 50 * nights;
                        apartment = 65 * nights;
                        if (nights > 7 && nights <= 14)
                        {
                            studio = 50 * nights - ((50 * nights) * 0.05);

                        }
                        else if (nights > 14)
                        {
                            apartment = 65 * nights - ((65 * nights) * 0.1);
                            studio = 50 * nights - ((50 * nights) * 0.30);
                        }
                        break;
                    }
                case "June":
                case "September":
                    {
                        studio = 75.2*nights;
                        apartment = 68.7*nights;
                        if (nights > 14)
                            apartment = 68.7 * nights - ((68.7 * nights) * 0.1);
                        studio = nights * (75.2 * 0.8);


                        break;
                    }
                case "July":
                case "August":
                    {
                        studio = 76*nights;
                        apartment = 77*nights;
                        if (nights > 14)
                            apartment = 77 * nights - ((77 * nights) * 0.1);
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {apartment:f2} lv.");
            Console.WriteLine($"Studio: {studio:f2} lv.");


        }
    }
}
