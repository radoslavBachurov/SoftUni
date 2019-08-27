using System;
using System.Globalization;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate = Console.ReadLine();
            DateTime day = DateTime.ParseExact(inputDate, "d-M-yyyy", CultureInfo.InvariantCulture);
            string dayOfWeek = day.DayOfWeek.ToString();
            Console.WriteLine(dayOfWeek);
        }
    }
}
