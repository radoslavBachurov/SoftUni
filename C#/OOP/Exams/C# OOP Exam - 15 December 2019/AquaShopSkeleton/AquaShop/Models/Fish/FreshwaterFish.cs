using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish, IFish
    {
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price, 3)
        {
        }

        public override void Eat()
        {
            this.Size += 3;
        }

        //Can only live in FreshwaterAquarium!
    }
}
