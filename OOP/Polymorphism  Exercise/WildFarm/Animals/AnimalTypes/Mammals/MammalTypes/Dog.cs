using System;

namespace WildFarm.Animals.Mammals.MammalTypes
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string food, int quantity)
        {
            if (food.ToLower() == "meat")
            {
                this.Weight += 0.40 * quantity;
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
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
