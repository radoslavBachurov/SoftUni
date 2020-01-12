using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] products = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Person> listOfPeople = new List<Person>();
            List<Products> listOfProducts = new List<Products>();

            AddingPeople(people, listOfPeople);

            AddingProducts(products, listOfProducts);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split().ToArray();
                string name = commandArr[0];
                string product = commandArr[1];

                BuyingProducts(listOfPeople, listOfProducts, name, product);
            }

            Printing(listOfPeople);
        }

        private static void Printing(List<Person> listOfPeople)
        {
            foreach (var person in listOfPeople)
            {
                if (person.BagProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join((", "), person.BagProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static void BuyingProducts(List<Person> listOfPeople, List<Products> listOfProducts, string name, string product)
        {
            Person personToCheck = listOfPeople.Find(x => x.Name == name);
            Products productToBuy = listOfProducts.Find(x => x.Name == product);

            if (personToCheck.Money >= productToBuy.Price)
            {
                Console.WriteLine($"{personToCheck.Name} bought {productToBuy.Name}");
                personToCheck.BagProducts.Add(productToBuy.Name);
                personToCheck.Money -= productToBuy.Price;

            }
            else
            {
                Console.WriteLine($"{personToCheck.Name} can't afford {productToBuy.Name}");
            }
        }

        private static void AddingProducts(string[] products, List<Products> listOfProducts)
        {
            for (int i = 0; i < products.Length; i += 2)
            {
                string name = products[i];
                decimal cost = decimal.Parse(products[i + 1]);

                Products newProduct = new Products(name, cost);
                listOfProducts.Add(newProduct);
            }
        }

        private static void AddingPeople(string[] people, List<Person> listOfPeople)
        {
            for (int i = 0; i < people.Length; i += 2)
            {
                string name = people[i];
                decimal money = decimal.Parse(people[i + 1]);

                Person newPerson = new Person(name, money);
                listOfPeople.Add(newPerson);
            }
        }
    }
    class Products
    {
        public Products(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagProducts = new List<string>();
        }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<string> BagProducts { get; set; }
    }
}
