using Newtonsoft.Json;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetStore.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PetStoreDbContext();
            var newServise = new PetStoreService(db);
            var sb = new StringBuilder();

            var petsJson = File.ReadAllText("Pets.json");
            var customersJson = File.ReadAllText("Customers.json");
            var foodsJson = File.ReadAllText("Foods.json");
            var toysJson = File.ReadAllText("Toys.json");

            GreateCustomer(newServise, sb, customersJson);

            CreatePet(newServise, sb, petsJson);

            CreateFood(newServise, sb, foodsJson);

            CreateToy(newServise, sb, toysJson);

            Console.WriteLine(sb.ToString().Trim());
            db.SaveChanges();
        }

        private static void CreateToy(PetStoreService newServise, StringBuilder sb, string toysJson)
        {
            var toys = JsonConvert.DeserializeObject<List<Toy>>(toysJson);
            foreach (var toy in toys)
            {
                sb.AppendLine(newServise.CreateToy(toy));
            }
        }

        private static void CreateFood(PetStoreService newServise, StringBuilder sb, string foodsJson)
        {
            var foods = JsonConvert.DeserializeObject<List<Food>>(foodsJson);
            foreach (var food in foods)
            {
                sb.AppendLine(newServise.CreateFood(food));
            }
        }

        private static void CreatePet(PetStoreService newServise, StringBuilder sb, string petsJson)
        {
            var pets = JsonConvert.DeserializeObject<List<PetDto>>(petsJson);
            foreach (var pet in pets)
            {
                sb.AppendLine(newServise.CreatePet(pet.Name, pet.Breed, pet.Age, pet.Gender, pet.Price));
            }
        }

        private static void GreateCustomer(PetStoreService newServise, StringBuilder sb, string customersJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customersJson);
            foreach (var customer in customers)
            {
                sb.AppendLine(newServise.CreateCustomer(customer));
            }
        }
    }

    class PetDto
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
    }
}
