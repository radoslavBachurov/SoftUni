﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BeverageMenu
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters) 
            : base(name, price, milliliters)
        {
        }
    }
}
