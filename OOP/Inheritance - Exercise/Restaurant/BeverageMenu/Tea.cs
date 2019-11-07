using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BeverageMenu
{
    public class Tea : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50m;

        public Tea(string name, decimal price, double milliliters, double caffeine)
            : base(name, price, milliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
        public override double Milliliters =>coffeeMilliliters;
        public decimal CofeePrice => coffeePrice;
    }
}
