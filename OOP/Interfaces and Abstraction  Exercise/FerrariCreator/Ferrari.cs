using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariCreator
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Model = model;
            this.Driver = driver;
        }

        public string Model { get; set; }
        public string Driver { get; set; }

        public string Break()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }
    }
}
