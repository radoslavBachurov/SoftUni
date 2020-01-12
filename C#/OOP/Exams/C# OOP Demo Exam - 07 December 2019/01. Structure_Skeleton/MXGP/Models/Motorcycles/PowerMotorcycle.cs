using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle, IMotorcycle
    {
        private const double cubicCM = 450;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, cubicCM)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if(value<70||value>100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }
}
