using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.TypeAnimals
{
    public class Kitten : Cat
    {
        private const string kittenCatGender = "Female";
        public Kitten(string name, int age) 
            : base(name, age, kittenCatGender)
        {
        }

        public override string ProduceSound()
        {
            string sound = "Meow";
            return sound;
        }
    }
}
