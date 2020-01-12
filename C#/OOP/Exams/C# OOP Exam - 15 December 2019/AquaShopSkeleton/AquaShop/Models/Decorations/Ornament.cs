using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration, IDecoration
    {
        public Ornament() 
            : base(1, 5)
        {
        }
    }
}
