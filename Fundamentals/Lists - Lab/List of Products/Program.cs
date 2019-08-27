using System;
using System.Collections.Generic;

namespace List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberProducts = int.Parse(Console.ReadLine());
            List<string> listProducts = new List<string>();

            for (int i = 0; i < numberProducts; i++)
            {
                listProducts.Add(Console.ReadLine());
            }

            listProducts.Sort();

            for (int i = 0; i < listProducts.Count; i++)
            {
                Console.WriteLine($"{i+1}.{listProducts[i]}");
            }
        }
    }
}
