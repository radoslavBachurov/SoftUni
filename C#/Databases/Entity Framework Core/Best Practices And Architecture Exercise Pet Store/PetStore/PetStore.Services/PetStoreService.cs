using Newtonsoft.Json;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Interfaces;
using PetStore.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PetStore.Services
{
    public class PetStoreService : IPetStoreService
    {
        private PetStoreDbContext db;
        private const string successCustomerMessage = "Successfully Added Customer {0}";
        private const string successPetMessage = "Successfully Added Pet {0}";
        private const string successToyMessage = "Successfully Added Toy {0}";
        private const string successFoodMessage = "Successfully Added Food {0}";
        private const string errorMessage = "Invalid or already existing entity!";
        private const string errorNotFound = "No entity with that name found";
        private const string successfullyAddedMessage = "Successfully added {0} to {1}";
        private const string errorSoldMessage = "Pet Already Sold";

        public PetStoreService(PetStoreDbContext context)
        {
            this.db = context;
        }

        public string CreateCustomer(Customer customer)
        {
            if (IsValid(customer))
            {
                db.Customers.Add(customer);
                return string.Format(successCustomerMessage, customer.FirstName + " " + customer.LastName);
            }

            return errorMessage;
        }

        public string CreateFood(Food food)
        {
            var isExist = db.Foods.FirstOrDefault(x => x.Name == food.Name);

            if (IsValid(food) && isExist == null)
            {
                db.Foods.Add(food);
                return string.Format(successFoodMessage, food.Name);
            }

            return errorMessage;
        }

        public string CreatePet(string name, string breed, int age, string gender, decimal price)
        {
            if (Enum.TryParse(breed, out PetBreedType petBreed) &&
                Enum.TryParse(gender, out PetGenderType petGender))
            {
                var newPet = new Pet()
                {
                    Age = age,
                    Breed = petBreed,
                    Gender = petGender,
                    Name = name,
                    Price = price
                };

                db.Pets.Add(newPet);
                return string.Format(successPetMessage, name);
            }

            return errorMessage;
        }

        public string CreateToy(Toy toy)
        {
            var isExist = db.Toys.FirstOrDefault(x => x.Name == toy.Name);

            if (IsValid(toy) && isExist == null)
            {
                db.Toys.Add(toy);
                return string.Format(successToyMessage, toy.Name);
            }

            return errorMessage;
        }

        public IEnumerable<PetView> GetNotSelledPets()
        {
            var notSelledPets = db.Pets
                .Where(x => x.CustomerId == null)
                .Select(x => new PetView { PetId = x.PetId, Price = x.Price, Name = x.Name, Breed = x.Breed.ToString() })
                .ToList();

            return notSelledPets;
        }

        public IEnumerable<ToyView> GetTopRatedToys()
        {
            var toys = db.Toys
                .Select(x => new ToyView()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Count = x.Customers.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(3)
                .ToArray();

            return toys;
        }

        public decimal GetTotalProfit()
        {
            var foodSells = db.FoodsSelled.Sum(x => x.Food.Price);
            var petSells = db.PetsSelled.Sum(x => x.Pet.Price);
            var toySells = db.ToysSelled.Sum(x => x.Toy.Price);

            return foodSells + petSells + toySells;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public void AddToyToCustomer(string customer, string toy)
        {
            var customerEntity = db.Customers.FirstOrDefault(x => x.FirstName + " " + x.LastName == customer);
            var toyEntity = db.Toys.FirstOrDefault(x => x.Name == toy);

            if (customerEntity == null || toyEntity == null)
            {
                Console.WriteLine(errorNotFound);
            }
            else
            {
                customerEntity.ToysBuyed.Add(new ToySelled() { ToyId = toyEntity.ToyId });
                db.SaveChanges();

                Console.WriteLine(string.Format(successfullyAddedMessage, toy, customer));
            }
        }
        public void AddPetToCustomer(string customer, string pet)
        {
            var customerEntity = db.Customers.FirstOrDefault(x => x.FirstName + " " + x.LastName == customer);
            var petEntity = db.Pets.FirstOrDefault(x => x.Name == pet);

            if (customerEntity == null || petEntity == null)
            {
                Console.WriteLine(errorNotFound);
            }
            else if (petEntity.IsSold)
            {
                Console.WriteLine(errorSoldMessage);
            }
            else
            {
                petEntity.CustomerId = customerEntity.CustomerId;
                customerEntity.PetsBuyed.Add(new PetSelled() { PetId = petEntity.PetId });
                db.SaveChanges();

                Console.WriteLine(string.Format(successfullyAddedMessage, pet, customer));
            }
        }
        public void AddFoodToCustomer(string customer, string food)
        {
            var customerEntity = db.Customers.FirstOrDefault(x => x.FirstName + " " + x.LastName == customer);
            var foodEntity = db.Foods.FirstOrDefault(x => x.Name == food);

            if (customerEntity == null || foodEntity == null)
            {
                Console.WriteLine(errorNotFound);
            }
            else
            {
                customerEntity.FoodsBuyed.Add(new FoodSelled() { FoodId = foodEntity.FoodId });
                db.SaveChanges();

                Console.WriteLine(string.Format(successfullyAddedMessage, food, customer));
            }
        }
    }
}
