using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle, IMotorcycle
    {
        private const double cubicCM = 125;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) :
            base(model, cubicCM)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }
}
