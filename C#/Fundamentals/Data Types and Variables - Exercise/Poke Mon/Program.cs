using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokeCount = 0;
            int pokePowerOrign = pokePower;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokeCount++;
                if (pokePowerOrign * 0.5 == pokePower && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCount);
        }
    }
}
