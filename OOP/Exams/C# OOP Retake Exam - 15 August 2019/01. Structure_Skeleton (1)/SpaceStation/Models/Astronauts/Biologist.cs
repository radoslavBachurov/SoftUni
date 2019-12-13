using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut, IAstronaut
    {
        private const double initialOxygen = 70;
        private const double oxygenDescrease = 5;
        public Biologist(string name) 
            : base(name, initialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - oxygenDescrease < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= oxygenDescrease;
            }
        }
    }
}
