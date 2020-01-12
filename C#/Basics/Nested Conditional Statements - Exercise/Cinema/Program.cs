using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());
            int numberSeats = rows * colums;
            double income = 0;

            switch (type)
            {
                case "Premiere":
                     income = numberSeats * 12.00;
                    
                    break;
                case "Normal":
                    income = numberSeats * 7.5;
                    
                    break;
                case "Discount":
                    income = numberSeats * 5.00;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");

        }
    }
}
