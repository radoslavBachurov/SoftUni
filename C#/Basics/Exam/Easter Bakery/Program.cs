using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceFlourPerKilo = double.Parse(Console.ReadLine());
            double kilosFlour = double.Parse(Console.ReadLine());
            double kilosSugar = double.Parse(Console.ReadLine());
            int eggPacks = int.Parse(Console.ReadLine());
            int mayPacks = int.Parse(Console.ReadLine());

            double priceSugarPerKilo = priceFlourPerKilo * 0.75;
            double pricePerEggPack = priceFlourPerKilo *1.1;
            double pricePerPackMay = priceSugarPerKilo * 0.2;

            double totalPrice = (kilosFlour * priceFlourPerKilo) + (kilosSugar * priceSugarPerKilo) + (eggPacks * pricePerEggPack) + (mayPacks * pricePerPackMay);
               Console.WriteLine($"{totalPrice:f2}");


        }
    }
}
