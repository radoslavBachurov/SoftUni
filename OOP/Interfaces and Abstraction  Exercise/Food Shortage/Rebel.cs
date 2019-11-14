﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
