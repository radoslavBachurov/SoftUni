using Animals.TypeAnimals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class AnimalFactory
    {
        private string[] animalInfo;
        private string typeAnimal;

        public AnimalFactory(string[] animalInfo, string type)
        {
            this.animalInfo = animalInfo;
            this.typeAnimal = type;
        }

        public Animal CreateAnimal()
        {
            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = animalInfo[2];

            Animal newAnimal = new Animal(name, age, gender);

            switch (typeAnimal)
            {
                case "Cat":
                    newAnimal = new Cat(name, age, gender);
                    break;
                case "Frog":
                    newAnimal = new Frog(name, age, gender);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, age, gender);
                    break;
                case "Kitten":
                    newAnimal = new Kitten(name, age);
                    break;
                case "Tomcat":
                    newAnimal = new Tomcat(name, age);
                    break;
            }

            return newAnimal;
        }
    }
}
