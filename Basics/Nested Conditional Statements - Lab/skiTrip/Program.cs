using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysStay = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string evaluate = Console.ReadLine();
            double pricePerNight = 0;
            double tripprice = 0;

            switch (typeRoom)
            {
                case "room for one person":
                   tripprice =  18;
                    


                    break;
                case "apartment":
                    pricePerNight = 25;
                    if (daysStay < 10)
                    {
                        tripprice = pricePerNight * 0.7;
                    }
                    else if (daysStay >= 10 && daysStay <= 15)
                    {
                        tripprice = pricePerNight * 0.65;
                    }
                    else if (daysStay > 15)
                    {
                        tripprice = pricePerNight * 0.5;
                    }
                    break;
                case "president apartment":

                    pricePerNight = 35;
                    if (daysStay < 10)
                    {
                        tripprice = pricePerNight * 0.9;
                    }
                    else if (daysStay >= 10 && daysStay <= 15)
                    {
                        tripprice =  pricePerNight * 0.85;
                    }
                    else if (daysStay > 15)
                    {
                        tripprice =  pricePerNight * 0.8;
                    }
                    break;

            }
            daysStay -= 1;
            tripprice = daysStay * tripprice;
            switch (evaluate)
            {
                case ("positive"):
                    Console.WriteLine($"{tripprice + (tripprice * 0.25):f2}");
                    break;
                case ("negative"):
                    Console.WriteLine($"{tripprice - (tripprice * 0.1):f2}");
                    break;
            }
        }
    }
}
