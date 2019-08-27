using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateCheck(order,quantity);
        }

        private static void CalculateCheck(string product , int quantity)
        {
            double sum = 0;
            switch (product)
            {
                case "coffee":
                    sum = quantity * 1.5;
                    break;
                case "water":
                    sum = quantity * 1;
                    break;
                case "coke":
                    sum = quantity * 1.4;
                    break;
                case "snacks":
                    sum = quantity * 2;
                    break;
            }
            Console.WriteLine($"{sum:f2}");
            
        }
    }
}
