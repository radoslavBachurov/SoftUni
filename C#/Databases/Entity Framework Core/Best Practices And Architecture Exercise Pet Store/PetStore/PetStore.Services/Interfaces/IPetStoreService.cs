using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Interfaces
{
    public interface IPetStoreService
    {
        string CreatePet(string name, string breed, int age, string gender, decimal price);

        string CreateToy(Toy toy);

        string CreateCustomer(Customer customer);

        string CreateFood(Food food);

        decimal GetTotalProfit();

        IEnumerable<PetView> GetNotSelledPets();

        IEnumerable<ToyView> GetTopRatedToys();

        void AddToyToCustomer(string customer,string toy);
        void AddPetToCustomer(string customer,string pet);
        void AddFoodToCustomer(string customer,string food);
    }
}
