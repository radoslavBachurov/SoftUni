﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.TypeAnimals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            string sound = "Woof!";
            return sound;
        }
    }
}
