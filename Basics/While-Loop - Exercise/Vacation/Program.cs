using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoneyTrip = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendMoneyCounter = 0;

            while (moneyAvailable<neededMoneyTrip)
            {
                string action = Console.ReadLine();
                double moneyForAction = double.Parse(Console.ReadLine());
                daysCounter++;
                if (action == "spend")
                {
                    moneyAvailable -= moneyForAction;
                    spendMoneyCounter++;
                    if (spendMoneyCounter == 5) 
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(daysCounter);
                        break;
                    }

                    else if (moneyAvailable < 0)
                    {
                        moneyAvailable = 0;
                    }
                    
                }

                else if(action == "save")
                {
                    moneyAvailable += moneyForAction;
                    spendMoneyCounter = 0;

                }
            }
            if (moneyAvailable >= neededMoneyTrip)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
