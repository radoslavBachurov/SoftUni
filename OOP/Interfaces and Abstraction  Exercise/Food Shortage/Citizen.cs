using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, string age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
            Food = 0;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
