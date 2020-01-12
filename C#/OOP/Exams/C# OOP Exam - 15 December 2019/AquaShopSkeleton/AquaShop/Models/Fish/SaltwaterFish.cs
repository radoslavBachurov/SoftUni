using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish, IFish
    {
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price, 5)
        {
        }

        public override void Eat()
        {
            this.Size += 2;
        }
        //Can only live in SaltwaterAquarium!
    }
}
