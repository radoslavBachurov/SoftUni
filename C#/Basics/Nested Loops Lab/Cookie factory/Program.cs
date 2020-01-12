using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountBatches = int.Parse(Console.ReadLine());
            int eggsCounter = 0;
            int flourCounter = 0;
            int sugarCounter = 0;
            for (int i = 1; i <= amountBatches; i++)
            {
                while (true)
                {
                    string products = Console.ReadLine();
                    switch (products)
                    {
                        case "flour":
                            flourCounter++;
                            break;
                        case "eggs":
                            eggsCounter++;
                            break;
                        case "sugar":
                            sugarCounter++;
                            break;
                    }
                    if (products == "Bake!" && eggsCounter > 0 && flourCounter > 0 && sugarCounter > 0)
                    {
                        Console.WriteLine($"Baking batch number {i}...");
                        flourCounter = 0;
                        eggsCounter = 0;
                        sugarCounter = 0;
                        break;
                    }
                    else if (products == "Bake!" && (eggsCounter == 0 || flourCounter == 0 || sugarCounter == 0))
                    {
                        Console.WriteLine($"The batter should contain flour, eggs and sugar!");
                    }
                }
                
               



            }
        }
    }
}
