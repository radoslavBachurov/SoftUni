
namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        void Sound();
        void Eat(string food, int quantity);
    }
}
