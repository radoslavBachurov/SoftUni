﻿using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        public Fish(string name, string species, decimal price, int size)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = size;
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFishName));
                }

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFishSpecies));
                }

                this.species = value;
            }
        }


        public int Size { get; protected set; }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFishPrice));
                }

                this.price = value;
            }
        }

        public abstract void Eat();

    }
}
