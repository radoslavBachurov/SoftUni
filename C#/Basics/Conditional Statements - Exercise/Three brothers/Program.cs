using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrother = double.Parse(Console.ReadLine());
            double secondBrother = double.Parse(Console.ReadLine());
            double thirdBrother = double.Parse(Console.ReadLine());
            double fishingTime = double.Parse(Console.ReadLine());

            double percentCleanForHour = 1 / firstBrother + 1 / secondBrother + 1 / thirdBrother;
            double timeToClean = 1 / percentCleanForHour;
            double timewithResess = timeToClean + (timeToClean * 0.15);
            double timeleft = fishingTime - timewithResess;

            Console.WriteLine($"Cleaning time: {timewithResess:f2}");

            if (timeleft >= 0)
            {
                timeleft = Math.Floor(timeleft);
                Console.WriteLine($"Yes, there is a surprise - time left -> {timeleft} hours.");
            }
            else if (timeleft < 0)
            {
                timeleft = Math.Ceiling(Math.Abs(timeleft));
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {timeleft} hours.");
            }

        }
    }
}
