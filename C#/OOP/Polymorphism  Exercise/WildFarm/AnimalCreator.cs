
using WildFarm.Animals.AnimalTypes.Birds;
using WildFarm.Animals.AnimalTypes.Birds.BirdTypes;
using WildFarm.Animals.Mammals.MammalTypes;
using WildFarm.Animals.Mammals.MammalTypes.Felines.FelinesTypes;
using WildFarm.Interfaces;

namespace WildFarm
{
    public static class AnimalCreator
    {
        public static IAnimal CreateAnimal(string[] inputArr)
        {
            IAnimal animal = null;

            switch (inputArr[0].ToLower())
            {
                case "tiger":
                    {
                        animal = new Tiger(inputArr[1], double.Parse(inputArr[2]), inputArr[3], inputArr[4]);
                    }
                    break;
                case "owl":
                    {
                        animal = new Owl(inputArr[1], double.Parse(inputArr[2]), double.Parse(inputArr[3]));
                    }
                    break;
                case "hen":
                    {
                        animal = new Hen(inputArr[1], double.Parse(inputArr[2]), double.Parse(inputArr[3]));
                    }
                    break;
                case "mouse":
                    {
                        animal = new Mouse(inputArr[1], double.Parse(inputArr[2]), inputArr[3]);
                    }
                    break;
                case "dog":
                    {
                        animal = new Dog(inputArr[1], double.Parse(inputArr[2]), inputArr[3]);
                    }
                    break;
                case "cat":
                    {
                        animal = new Cat(inputArr[1], double.Parse(inputArr[2]), inputArr[3], inputArr[4]);
                    }
                    break;
            }

            return animal;
        }
    }
}
