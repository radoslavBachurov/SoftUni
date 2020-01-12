using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class Engine
    {
        private List<IAnimal> listOfAnimals;

        public Engine()
        {
            listOfAnimals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                IAnimal newAnimal =  AnimalCreator.CreateAnimal(animalInput);

                string[] foodInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                newAnimal.Eat(foodInput[0], int.Parse(foodInput[1]));

                listOfAnimals.Add(newAnimal);
            }

            Printing();
        }

        private void Printing()
        {
            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
