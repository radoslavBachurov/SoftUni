using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.FoodMenu
{
    public class Soup : Starter
    {
        private const double grams = 22;

        public Soup(string name, decimal price, double grams)
            : base(name, price, grams)
        {
            
        }

        public override double Grams => grams;
    }
}

