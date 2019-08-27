﻿using System;

namespace Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeday = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (age >= 0 && age <= 122)
            {
                switch (typeday)
                {
                    case "Weekday":
                        {
                            if (age >= 0 && age <= 18)
                                ticketPrice = 12;
                            else if (age > 18 && age <= 64)
                                ticketPrice = 18;
                            else if (age <= 122)
                                ticketPrice = 12;
                            break;
                        }
                    case "Weekend":
                        {
                            if (age >= 0 && age <= 18)
                                ticketPrice = 15;
                            else if (age > 18 && age <= 64)
                                ticketPrice = 20;
                            else if (age <= 122)
                                ticketPrice = 15;

                        }
                        break;
                    case "Holiday":
                        {
                            if (age >= 0 && age <= 18)
                                ticketPrice = 5;
                            else if (age > 18 && age <= 64)
                                ticketPrice = 12;
                            else if (age <= 122)
                                ticketPrice = 10;

                        }
                        break;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else
                Console.WriteLine("Error!");


        }
    }
}
