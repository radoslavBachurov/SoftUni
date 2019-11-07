using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.FoodMenu
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 1000;
        private const double cakePrice = 5;

        public Cake(string name, decimal price, double grams, double calories)
            : base(name, price, grams, calories)
        {
        }

        public override double Grams => grams;
        public override double Calories => calories;
        public double CakePrice => cakePrice;
    }
}
