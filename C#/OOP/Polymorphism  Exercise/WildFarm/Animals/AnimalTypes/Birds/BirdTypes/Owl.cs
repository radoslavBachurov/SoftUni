using System;


namespace WildFarm.Animals.AnimalTypes.Birds.BirdTypes
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string food, int quantity)
        {
            if (food.ToLower() == "meat")
            {
                this.Weight += 0.25*quantity;
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
            Console.WriteLine("Hoot Hoot");
        }
    }
}
