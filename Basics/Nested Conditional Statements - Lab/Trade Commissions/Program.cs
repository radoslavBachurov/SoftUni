using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sellAmount = double.Parse(Console.ReadLine());
            //double commission = Sell amount * percent;
            double commission = 0;
            
            switch (city)
            {
                case "Sofia":
                    if (0 <= sellAmount && sellAmount <=500)
                    {
                        commission = sellAmount * 0.05;
                    }
                    else if (500<sellAmount && sellAmount <= 1000)
                    {
                        commission = sellAmount * 0.07;
                    }
                    else if (1000 < sellAmount && sellAmount <= 10000)
                    {
                        commission = sellAmount * 0.08;
                    }
                    else if (sellAmount > 10000)
                    {
                        commission = sellAmount * 0.12;
                    }
                    
                    break;
                case "Varna":
                    if (0 <= sellAmount && sellAmount <= 500)
                    {
                        commission = sellAmount * 0.045;
                    }
                    else if (500 < sellAmount && sellAmount <= 1000)
                    {
                        commission = sellAmount * 0.075;
                    }
                    else if (1000 < sellAmount && sellAmount <= 10000)
                    {
                        commission = sellAmount * 0.1;
                    }
                    else if (sellAmount > 10000)
                    {
                        commission = sellAmount * 0.13;
                    }
                    
                    break;
                case "Plovdiv":
                    if (0 <= sellAmount && sellAmount <= 500)
                    {
                        commission = sellAmount * 0.055;
                    }
                    else if (500 < sellAmount && sellAmount <= 1000)
                    {
                        commission = sellAmount * 0.08;
                    }
                    else if (1000 < sellAmount && sellAmount <= 10000)
                    {
                        commission = sellAmount * 0.12;
                    }
                    else if (sellAmount > 10000)
                    {
                        commission = sellAmount * 0.145;
                    }
                    
                    break;
            }
            if (sellAmount<0)
            {
                Console.WriteLine("error");
            }
            else if (sellAmount>=0 && (city == "Sofia" || city == "Varna" || city == "Plovdiv"))
            {
                Console.WriteLine($"{commission:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
