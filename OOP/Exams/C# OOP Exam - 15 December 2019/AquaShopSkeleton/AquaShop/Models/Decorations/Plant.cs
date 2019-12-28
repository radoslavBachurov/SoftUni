using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration, IDecoration
    {
        public Plant() 
            : base(5, 10)
        {
        }
    }
}
