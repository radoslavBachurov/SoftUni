using Animals.TypeAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private List<Animal> myList;

        public Engine()
        {
            myList = new List<Animal>();
        }

        public void Run()
        {
            string typeAnimal = string.Empty;
            while ((typeAnimal = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    if (typeAnimal.Length == 0)
                    {
                        throw new ArgumentException();
                    }

                    string[] animalInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (animalInfo.Length < 3)
                    {
                        throw new ArgumentException();
                    }

                    var newFactory = new AnimalFactory(animalInfo, typeAnimal);
                    myList.Add(newFactory.CreateAnimal());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Printing();
        }

        private void Printing()
        {
            foreach (var animal in myList)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
