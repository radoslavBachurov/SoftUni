using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summer_outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int celsium = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();
            string outfit = string.Empty;
            string shoes = string.Empty;

            switch (dayTime)
            {
                case "Morning":
                   if (10 <= celsium && celsium <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                   if (18 < celsium && celsium <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                   if (celsium >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (10 <= celsium && celsium <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    if (18 < celsium && celsium <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    if (celsium >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    if (10 <= celsium && celsium <= 18)
                    {
                        outfit = "Shirt";
                            shoes = "Moccasins";
                    }
                    if (18 < celsium && celsium <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                        if (celsium >= 25)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;
            }
            Console.WriteLine($"It's {celsium} degrees, get your {outfit} and {shoes}.");
        }
        
        
    }
}
