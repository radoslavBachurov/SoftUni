using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int quot = int.Parse(Console.ReadLine());
            double fishSum = 0;
            double fishTax = 0;
            int counter = 0;
            double totalSum = 0;

            for (int i = 1; i <= quot; i++)
            {
                string fishName = Console.ReadLine();
                if (fishName == "Stop")
                {
                    break;
                }
                double kilos = double.Parse(Console.ReadLine());

                fishSum = 0;
                fishTax = 0;
                counter++;
                int nameLength = fishName.Length;

                for (int f = 0; f < nameLength; f++)
                {
                    fishSum += fishName[f];
                    
                }

                fishTax = fishSum / kilos;

                if (counter % 3 == 0)
                {
                    totalSum += fishTax;
                }
                else
                {
                    totalSum -= fishTax;
                }
            }
            if (counter == quot)
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
            }
            if (totalSum > 0)
            {
                Console.WriteLine($"Lyubo's profit from {counter} fishes is {totalSum:f2} leva.");
            }
            else if (totalSum <= 0)
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(totalSum):f2} leva today.");
            }
        }
    }
}
