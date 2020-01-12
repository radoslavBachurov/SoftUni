using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTransactions = int.Parse(Console.ReadLine());
            int transactionCount = 1;
            double accountBalance = 0;
                
            while (numberTransactions>=transactionCount)
            {
                 double accountIncome = double.Parse(Console.ReadLine());
                if (accountIncome >= 0)
                {
                    Console.WriteLine($"Increase: {accountIncome:f2}");
                    accountBalance += accountIncome;
                    transactionCount++;
                }
                else if(accountIncome < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }

            Console.WriteLine($"Total: {accountBalance:f2}");
        }
    }
}
