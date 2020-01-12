using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            long startinYeld = long.Parse(Console.ReadLine());
            int dayCounter = 0;
            long sumSpice = 0;

            if (startinYeld < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);
            }
            else
            {
                while (true)
                {
                    dayCounter++;
                    sumSpice += startinYeld;
                    startinYeld -= 10;
                    sumSpice -= 26;
                    if (startinYeld < 100)
                    {
                        break;
                    }
                }
                if (sumSpice >= 26)
                {
                    Console.WriteLine(dayCounter);
                    Console.WriteLine(sumSpice - 26);
                }
            }
        }
    }
}