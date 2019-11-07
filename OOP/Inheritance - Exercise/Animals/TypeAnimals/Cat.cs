﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.TypeAnimals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            string sound = "Meow meow";
            return sound;
        }
    }
}
