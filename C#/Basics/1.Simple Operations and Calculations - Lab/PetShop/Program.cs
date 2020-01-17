using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFoodPrice = 2.5;
            double otherAnimalFoodPrice = 4;

            int dogCount = int.Parse(Console.ReadLine());
            int otherAnimalCount = int.Parse(Console.ReadLine());

            double moneyForDogs = dogFoodPrice * dogCount;
            double moneyForOtherAnimals = otherAnimalCount * otherAnimalFoodPrice;

            Console.WriteLine($"{moneyForDogs+moneyForOtherAnimals:f2} lv.");
        }
    }
}
