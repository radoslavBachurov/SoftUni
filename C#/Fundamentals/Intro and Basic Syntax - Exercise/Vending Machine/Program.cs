using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumCoins = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Start")
                    break;
                double coins = double.Parse(command);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sumCoins += coins;
                }
                else
                    Console.WriteLine($"Cannot accept {coins}");
            }

            string product = Console.ReadLine().ToLower();
            while (product != "end")
            {
                bool validProduct = true;
                double sumOrign = sumCoins;
                switch (product)
                {
                    case "nuts":
                        sumCoins -= 2.0;
                        break;
                    case "water":
                        sumCoins -= 0.7;
                        break;
                    case "crisps":
                        sumCoins -= 1.5;
                        break;
                    case "soda":
                        sumCoins -= 0.8;
                        break;
                    case "coke":
                        sumCoins -= 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        validProduct = false;
                        break;
                }

                if (sumCoins >= 0 && validProduct == true)
                    Console.WriteLine($"Purchased {product}");

                else if (sumCoins < 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    sumCoins = sumOrign;
                }
                product = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Change: {sumCoins:f2}");
        }
    }
}
