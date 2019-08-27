using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            switch (city)
            {
                case "Sofia":
                    switch (product)
                    {
                        case "coffee":
                           price = quantity * 0.50;
                            break;
                        case "water":
                            price = quantity * 0.80;
                            break;
                        case "beer":
                            price = quantity * 1.20;
                            break;
                        case "sweets":
                            price = quantity * 1.45;
                            break;
                        case "peanuts":
                            price = quantity * 1.60;
                            break;


                    }
                    break;

                case "Varna":
                    switch (product)
                    {
                        case "coffee":
                            price = quantity * 0.45;
                            break;
                        case "water":
                            price = quantity * 0.70;
                            break;
                        case "beer":
                            price = quantity * 1.10;
                            break;
                        case "sweets":
                            price = quantity * 1.35;
                            break;
                        case "peanuts":
                            price = quantity * 1.55;
                            break;


                    }
                    break;
                case "Plovdiv":
                    switch (product)
                    {
                        case "coffee":
                            price = quantity * 0.40;
                            break;
                        case "water":
                            price = quantity * 0.70;
                            break;
                        case "beer":
                            price = quantity * 1.15;
                            break;
                        case "sweets":
                            price = quantity * 1.30;
                            break;
                        case "peanuts":
                            price = quantity * 1.50;
                            break;


                    }
                    break;

            }
            Console.WriteLine(price);
        }
    }
}
