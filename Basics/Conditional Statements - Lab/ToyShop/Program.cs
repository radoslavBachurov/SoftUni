using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double trip = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int talkingdolls = int.Parse(Console.ReadLine());
            int tedybears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzelsprofit = 2.60*puzzels;
            double talkingdollsprofit =3*talkingdolls;
            double tedybearsprofit =4.10*tedybears;
            double minionsprofit =8.2*minions;
            double trucksprofit =2*trucks;
            double profit = puzzelsprofit + talkingdollsprofit + tedybearsprofit + minionsprofit + trucksprofit;
            int toynumber = puzzels + talkingdolls + tedybears + minions + trucks;
            if (toynumber >= 50)
            {
                profit = profit - (profit * 0.25);
            }
            double afterrent = profit - (profit * 0.10);
            double aftertrip = Math.Abs( afterrent - trip);
            if (afterrent >= trip)
            {
                Console.WriteLine($"Yes! {aftertrip:f2} lv left.");
            }
            else if (afterrent < trip)
            {
                Console.WriteLine($"Not enough money! {aftertrip:f2} lv needed.");
            }
            
            

        }
    }
}
