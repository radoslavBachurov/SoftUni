using System;

namespace Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal priceForKiloFlower = decimal.Parse(Console.ReadLine());

            decimal pricePackEggs = priceForKiloFlower * 0.75m;
            decimal quaterLitreMilk = (priceForKiloFlower * 1.25m) / 4m;
            decimal priceForCozonac = priceForKiloFlower + pricePackEggs + quaterLitreMilk;

            int cozonakCounter = 0;
            int coloredEggCounter = 0;

            
            while (budget>=priceForCozonac)
            {
                budget -= priceForCozonac;
                cozonakCounter++;
                coloredEggCounter += 3;

                if (cozonakCounter % 3 == 0)
                {
                    coloredEggCounter -= cozonakCounter - 2;
                }

                if (budget - priceForCozonac < 0m)
                {
                    break;
                }

            }

            Console.WriteLine($"You made {cozonakCounter} cozonacs! Now you have {coloredEggCounter} eggs and {budget:f2}BGN left.");

        }
    }
}
