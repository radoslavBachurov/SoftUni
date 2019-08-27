using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGuests = int.Parse(Console.ReadLine());
            double pricePerGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (numberGuests>=10 && numberGuests<=15)
            {
                pricePerGuest *= 0.85;
            }
            else if (numberGuests>15 && numberGuests<=20)
            {
                pricePerGuest *= 0.8;
            }
            else if (numberGuests>20)
            {
                pricePerGuest *= 0.75;
            }
            double cake = budget * 0.1;
            double guestsPrice = numberGuests * pricePerGuest;
            double totalPrice = budget - (cake + guestsPrice);
            if(totalPrice>=0)
            {
                Console.WriteLine($"It is party time! {totalPrice:f2} leva left.");
            }
            else if (totalPrice<0)
            {
                Console.WriteLine($"No party! {Math.Abs(totalPrice):f2} leva needed.");
            }
        
        }
    }
}
