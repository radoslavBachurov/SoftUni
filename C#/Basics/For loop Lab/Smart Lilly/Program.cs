using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Lilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int Age = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int birthayMoneyRise = 0;
            int takenMoney = 0;
            double moneyFromToys = 0;
            int birthayRaiseProfit = 0;

            for (int i = 1; i <= Age; i++)
            {
                if (i % 2 == 0)
                {
                    birthayRaiseProfit += 10; 
                    birthayMoneyRise += birthayRaiseProfit;
                    takenMoney += 1;
                }
                else if(i % 2 != 0)
                {
                    moneyFromToys += toyPrice;
                }
            }

            double moneyRaised = birthayMoneyRise + moneyFromToys - takenMoney;

            if(moneyRaised >= washerPrice)
            {
                Console.WriteLine($"Yes! {(moneyRaised-washerPrice):f2}");
            }
            else if (moneyRaised < washerPrice)
            {
                Console.WriteLine($"No! {washerPrice-moneyRaised:f2}");
            }
        }
    }
}
