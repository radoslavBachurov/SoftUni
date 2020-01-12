using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int sumtime = firstTime + secondTime + thirdTime;
            double secondsToMinutes = Math.Floor(sumtime / 60.0);
            double secondsToSeconds = sumtime % 60.0;

            if (secondsToSeconds < 10)
            {
                Console.WriteLine($"{secondsToMinutes}:0{secondsToSeconds}");
            }
            else if (secondsToSeconds >= 10)
            {
                Console.WriteLine($"{secondsToMinutes}:{secondsToSeconds}");
            }
            
        }
    }
}
