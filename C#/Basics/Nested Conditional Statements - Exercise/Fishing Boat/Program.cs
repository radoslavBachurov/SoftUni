using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFisherman = int.Parse(Console.ReadLine());
            int rent = 0;
            double disrent = 0;
            switch (season)
            {
                case "Spring":
                    rent = 3000;

                    break;
                case "Summer":
                    rent = 4200;
                    break;
                case "Autumn":
                    rent = 4200;
                    break;
                case "Winter":
                    rent = 2600;
                    break;
            }
            if (numberFisherman <= 6)
            {
                 disrent = rent - (rent * 0.10);
            }
            else if (numberFisherman >= 7 && numberFisherman <= 11)
            {
                 disrent = rent - (rent * 0.15);
            }
            else if (numberFisherman >= 12)
            {
                 disrent = rent - (rent * 0.25);
            }
            double secRent = disrent - (disrent * 0.05);

            if (numberFisherman % 2 == 0 && (season == "Winter" || season == "Spring" || season == "Summer"))
            {
                
                if (secRent <= groupBudget)
                {
                    double leftmoney = groupBudget - secRent;
                    Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                }
                else
                {
                    double moneyneeded = secRent - groupBudget;
                    Console.WriteLine($"Not enough money! You need {moneyneeded:f2} leva.");
                }
            }

            else
            {
                if (disrent <= groupBudget)
                {
                    double leftmoney = groupBudget - disrent;
                    Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");

                }
                else
                {
                    double moneyneeded = disrent - groupBudget;
                    Console.WriteLine($"Not enough money! You need {moneyneeded:f2} leva.");
                }
            }
        }
    }
}
