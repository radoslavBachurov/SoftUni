using System;

namespace WildFarm.Animals.Mammals.MammalTypes
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string food, int quantity)
        {
            if (food.ToLower() == "vegetable" || food.ToLower() == "fruit")
            {
                this.Weight += 0.10 * quantity;
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
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
