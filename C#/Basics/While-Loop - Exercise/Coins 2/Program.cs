using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins_2
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountChange = decimal.Parse(Console.ReadLine());

            int coinsCounter = 0;

            while (amountChange != 0)
            {
                if (amountChange >= 2m)
                {
                    amountChange -= 2m;
                    coinsCounter++;
                }
                else if (amountChange >= 1m)
                {
                    amountChange -= 1m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.5m)
                {
                    amountChange -= 0.5m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.2m)
                {
                    amountChange -= 0.2m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.1m)
                {
                    amountChange -= 0.1m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.05m)
                {
                    amountChange -= 0.05m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.02m)
                {
                    amountChange -= 0.02m;
                    coinsCounter++;
                }
                else if (amountChange >= 0.01m)
                {
                    amountChange -= 0.01m;
                    coinsCounter++;
                }


            }
            Console.WriteLine(coinsCounter);
        }
    }
}
