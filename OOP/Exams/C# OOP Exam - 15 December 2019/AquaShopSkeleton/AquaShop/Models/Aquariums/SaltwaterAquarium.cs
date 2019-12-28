using AquaShop.Models.Aquariums.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium, IAquarium
    {
        public SaltwaterAquarium(string name) 
            : base(name, 25)
        {
        }
    }
}
