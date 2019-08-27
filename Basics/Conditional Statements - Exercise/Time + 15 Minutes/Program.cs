using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinute = int.Parse(Console.ReadLine());

            int hourInMinutes = startHour * 60;
            int sumHours = hourInMinutes + startMinute+15;
            double minutesToHoursH = sumHours / 60;
            double minutesTohoursM = sumHours % 60;

            if (minutesToHoursH >= 24)
            {
                if (minutesTohoursM < 10)
                {
                    Console.WriteLine($"0:0{minutesTohoursM}");
                }
                else if (minutesTohoursM >= 10)
                {
                    Console.WriteLine($"0:{minutesTohoursM}");
                }
            }
            if (minutesToHoursH < 24)
            {
                if (minutesTohoursM < 10)
                {
                    Console.WriteLine($"{minutesToHoursH}:0{minutesTohoursM}");
                }
                else if (minutesTohoursM >= 10)
                {
                    Console.WriteLine($"{minutesToHoursH}:{minutesTohoursM}");
                }
            }

        }
    }
}
