using System;

namespace WildFarm.Animals.Mammals.MammalTypes.Felines.FelinesTypes
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string food, int quantity)
        {
            if (food.ToLower() == "vegetable" || food.ToLower() == "meat")
            {
                this.Weight += 0.30 * quantity;
                this.FoodEaten += quantity;
                Sound();
            }
            else
            {
                Sound();
                Console.WriteLine($"{GetType().Name} does not eat {food}!");
            }
        }

        public override void Sound()
        {
            Console.WriteLine("Meow");
        }
    }
}
