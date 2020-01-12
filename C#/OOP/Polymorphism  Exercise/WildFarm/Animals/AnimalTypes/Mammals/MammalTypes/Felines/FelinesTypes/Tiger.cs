using System;

namespace WildFarm.Animals.Mammals.MammalTypes.Felines.FelinesTypes
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string food, int quantity)
        {
            if (food.ToLower() == "meat")
            {
                this.Weight += 1 * quantity;
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
            Console.WriteLine("ROAR!!!");
        }
    }
}
