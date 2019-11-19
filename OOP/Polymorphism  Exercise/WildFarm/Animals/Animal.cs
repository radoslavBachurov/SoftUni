
using WildFarm.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void Sound();

        public abstract void Eat(string food, int quantity);

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name},";
        }
    }
}
