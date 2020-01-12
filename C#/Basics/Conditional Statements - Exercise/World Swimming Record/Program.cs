using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distanceMetres = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            
            double slowingPerMeter1 = Math.Floor(distanceMetres / 15);
            double slowingPerMeter2 = slowingPerMeter1 * 12.5;
            double ivanTimeClear = distanceMetres * secondsPerMeter;
            double ivanTime = ivanTimeClear + slowingPerMeter2;
            double failedRecord = ivanTime - worldRecord;

            if (ivanTime<worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanTime:f2} seconds.");
            }
            else if (ivanTime>=worldRecord)
            {
                Console.WriteLine($"No, he failed! He was {failedRecord:f2} seconds slower.");
            }

            
        }
    }
}
