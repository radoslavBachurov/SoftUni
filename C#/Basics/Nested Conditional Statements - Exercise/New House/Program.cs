using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double Roses = 5.0;
            double Dahlias = 3.8;
            double Tulips = 2.8;
            double Narcissus = 3.0;
            double Gladiolus = 2.5;
            double sum = 0;

            switch (typeFlowers)
            {
                case "Dahlias":
                    if (numberFlowers > 90)
                    {
                        double DahliasPrice = numberFlowers * Dahlias;
                        sum = DahliasPrice - (DahliasPrice * 0.15);
                    }


                    else if (numberFlowers <= 90)
                    {
                        sum = numberFlowers * Dahlias;
                        
                    }

                        break;
                case "Tulips":
                    if (numberFlowers > 80)
                    {
                        double tulipsPrice = numberFlowers * Tulips;
                        sum = tulipsPrice - (tulipsPrice * 0.15);
                    }
                    else if (numberFlowers <= 80)
                    {
                        sum = numberFlowers * Tulips;

                    }
                    break;
                case "Roses":
                    if (numberFlowers > 80)
                    {
                        double rosesPrice = numberFlowers * Roses;
                        sum = rosesPrice - (rosesPrice * 0.10);
                    }
                    else if (numberFlowers <= 80)
                    {
                        sum = numberFlowers * Roses;

                    }
                    break;
                case "Narcissus":
                    if (numberFlowers <120)
                    {
                        double narcissusPrice = numberFlowers * Narcissus;
                        sum = narcissusPrice + (narcissusPrice * 0.15);
                    }
                    else if (numberFlowers >= 120)
                    {
                        sum = numberFlowers * Narcissus;

                    }
                    break;
                case "Gladiolus":
                    if(numberFlowers<80)
                    {
                        double gladiolusPrice = numberFlowers * Gladiolus;
                        sum = gladiolusPrice + (gladiolusPrice * 0.20);
                    }
                    else if (numberFlowers >= 80)
                    {
                        sum = numberFlowers * Gladiolus;

                    }
                    break;
            }
            if (budget >= sum)

            {
                double moneyleft = budget - sum;
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {typeFlowers} and {moneyleft:f2} leva left.");
            }
            else 
            {
                double moneyNeeded = sum - budget;
                Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
            }
        }
    }
}
