using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> listOfProducts = new Dictionary<string, Product>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArr = input.Split().ToArray();
                string product = inputArr[0];
                decimal price = decimal.Parse(inputArr[1]);
                int quantity = int.Parse(inputArr[2]);
                Product priceQuantity = new Product(price, quantity);

                if (!listOfProducts.ContainsKey(product))
                {
                    listOfProducts.Add(product, priceQuantity);
                }
                else
                {
                    listOfProducts[product].Price = price;
                    listOfProducts[product].Quantity += quantity;
                }
            }

            foreach (var item in listOfProducts)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value.Price * item.Value.Quantity):f2}");
            }
        }
    }
    class Product
    {
        public Product(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
