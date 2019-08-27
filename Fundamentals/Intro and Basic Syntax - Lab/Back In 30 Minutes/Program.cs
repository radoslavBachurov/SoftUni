using System;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            TimeSpan arrival = new TimeSpan(hours, minutes, 0);
            TimeSpan wait = new TimeSpan(0, 30, 0);
            TimeSpan finalHour = arrival + wait;

            if (finalHour.Minutes >= 0 && finalHour.Minutes <= 9)
                Console.WriteLine($"{finalHour.Hours}:0{finalHour.Minutes}");

            else
                Console.WriteLine($"{finalHour.Hours}:{finalHour.Minutes}");
        }
    }
}
