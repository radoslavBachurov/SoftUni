using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberKozunacs = int.Parse(Console.ReadLine());
            int maxSugar = int.MinValue;
            int maxFlour = int.MinValue;
            double sumFlourSpend = 0.0;
            double sumSugarSpend = 0.0;

            for (int i = 0; i < numberKozunacs; i++)
            {
                int sugarSpend = int.Parse(Console.ReadLine());
                int flourSpend = int.Parse(Console.ReadLine());
                sumFlourSpend += flourSpend;
                sumSugarSpend += sugarSpend;
                if (maxSugar<sugarSpend)
                {
                    maxSugar = sugarSpend;
                }
                if(maxFlour<flourSpend)
                {
                    maxFlour = flourSpend;
                }
            }
            double sugarpacksNeeded = Math.Ceiling( sumSugarSpend / 950);
            double flourpacksNeeded = Math.Ceiling(sumFlourSpend / 750);
            Console.WriteLine($"Sugar: {sugarpacksNeeded}");
            Console.WriteLine($"Flour: {flourpacksNeeded}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
