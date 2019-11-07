using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.TypeAnimals
{
    public class Tomcat : Cat
    {
        private const string tomCatGender = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, tomCatGender)
        {
        }

        public override string ProduceSound()
        {
            string sound = "MEOW";
            return sound;
        }
    }
}
