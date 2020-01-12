using System;

namespace WildFarm.Animals.AnimalTypes.Birds.BirdTypes
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string food, int quantity)
        {
            this.Weight += 0.35 * quantity;
            this.FoodEaten += quantity;
            Sound();
        }

        public override void Sound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
