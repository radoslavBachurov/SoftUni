using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            int numberHours = int.Parse(Console.ReadLine());
            double parkPrice = 0;
            int t = 0;
            

            for (int i = 1; i <= numberDays; i++)
            {
                double dayPrice = 0;
                if (i % 2 == 0)
                {
                    for ( t = 1; t <= numberHours; t++)
                    {
                        if (t % 2 != 0)
                        {
                            dayPrice += 2.5;
                        }
                        else
                        {
                            dayPrice += 1;
                        }
                    }
                }
                else if (i % 2 != 0)
                {
                    for ( t = 1; t <= numberHours; t++)
                    {
                        if (t % 2 == 0)
                        {
                            dayPrice += 1.25;
                        }
                        else
                        {
                            dayPrice += 1;
                        }
                    }

                }
                parkPrice += dayPrice;
                Console.WriteLine($"Day: {i} - {dayPrice:f2} leva");
            }
            Console.WriteLine($"Total: {parkPrice:f2} leva");

        }
    }
}
