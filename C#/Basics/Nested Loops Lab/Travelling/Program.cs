using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double tripPrice = double.Parse(Console.ReadLine());
                double money = 0;
                string moneyOrEnd = "Empty";

                while (true)
                {
                    moneyOrEnd = Console.ReadLine();
                    if (moneyOrEnd == "End")
                    {
                        break;
                    }
                    money += double.Parse(moneyOrEnd);
                    if (money >= tripPrice)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
                if (moneyOrEnd == "End")
                {
                    break;
                }
            }
        }
    }
}
