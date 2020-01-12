using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeList = new Dictionary<string, List<Product>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArr = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string store = inputArr[0];
                string productName = inputArr[1];
                double price = double.Parse(inputArr[2]);

                if(!storeList.ContainsKey(store))
                {
                    storeList.Add(store, new List<Product>());
                }

                storeList[store].Add(new Product(productName, price));
            }

            foreach (var store in storeList.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.ProductName}, Price: {product.Price}");
                }
            }
        }
    }
    class Product
    {
        public Product(string productName, double price)
        {
            ProductName = productName;
            Price = price;
        }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
