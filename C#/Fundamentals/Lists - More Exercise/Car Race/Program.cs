using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split().Select(int.Parse).ToList();
            double sumFirstRacer = 0;
            double sumSecondRacer = 0;

            for (int i = 0; i < times.Count / 2; i++)
            {
                sumFirstRacer += times[i];
                if (times[i] == 0)
                {
                    sumFirstRacer *= 0.8;
                }
            }

            for (int i = times.Count - 1; i >= times.Count / 2 + 1; i--)
            {
                sumSecondRacer += times[i];
                if (times[i] == 0)
                {
                    sumSecondRacer *= 0.8;
                }
            }

            if (sumFirstRacer<sumSecondRacer)
            {
                Console.WriteLine($"The winner is left with total time: {sumFirstRacer}");
            }
            else if(sumFirstRacer>sumSecondRacer)
            {
                Console.WriteLine($"The winner is right with total time: {sumSecondRacer}");
            }

        }
    }
}
