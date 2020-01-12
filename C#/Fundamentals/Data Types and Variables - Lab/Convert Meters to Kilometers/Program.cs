using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int metres = int.Parse(Console.ReadLine());

            double kilometres = metres / 1000.0;
            Console.WriteLine($"{kilometres:f2}");
        }
    }
}
