using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private const double oxygenDescrease = 10;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (this.oxygen - oxygenDescrease < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= oxygenDescrease;
            }
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.Append($"Name: {this.name}\r\n");
            newSB.Append($"Oxygen: {this.oxygen}\r\n");

            if (this.Bag.Items.Any())
            {
                newSB.Append($"Bag items: {string.Join(", ", this.Bag.Items)}\r\n");
            }
            else
            {
                newSB.Append($"Bag items: none\r\n");
            }
            return newSB.ToString().TrimEnd();
        }
    }
}
