using System;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] day =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 7)
                Console.WriteLine("Invalid day!");
            else
                Console.WriteLine(day[number-1]);
        }
    }
}
