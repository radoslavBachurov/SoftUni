using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journeyy
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "somewhere";
            string typeVacation = "campOrHotel";
            double moneySpend = 0;

            if (budget<=100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        typeVacation = "Camp";
                        moneySpend = budget * 0.3;
                        break;
                    case "winter":
                        typeVacation = "Hotel";
                        moneySpend = budget * 0.7;
                        break;
                }
            }
            if (budget <= 1000 && budget>100)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        typeVacation = "Camp";
                        moneySpend = budget * 0.4;
                        break;
                    case "winter":
                        typeVacation = "Hotel";
                        moneySpend = budget * 0.8;
                        break;
                }
            }
            if (budget > 1000)
            {
                typeVacation = "Hotel";
                destination = "Europe";
                moneySpend = budget * 0.9;
            }
            moneySpend = Math.Round(moneySpend, 2);
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeVacation} - {moneySpend:f2}");

        }  
    }
}
