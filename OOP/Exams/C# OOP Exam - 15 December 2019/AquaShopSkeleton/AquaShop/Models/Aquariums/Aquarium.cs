using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorationsList;
        private List<IFish> fishList;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorationsList = new List<IDecoration>();
            this.fishList = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
        {
            get
            {
                int sum = 0;
                foreach (var item in this.Decorations)
                {
                    sum += item.Comfort;
                }
                return sum;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorationsList.AsReadOnly();

        public ICollection<IFish> Fish => this.fishList.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorationsList.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity > this.Fish.Count)
            {
                this.fishList.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"{this.name} ({GetType().Name}):");
            if (this.Fish.Any())
            {
                newSB.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(x => x.Name))}");

            }
            else
            {
                newSB.AppendLine("Fish: none");
            }

            newSB.AppendLine($"Decorations: {this.Decorations.Count}");
            newSB.AppendLine($"Comfort: { this.Comfort}");

            return newSB.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.Fish.Any(x => x.Name == fish.Name))
            {
                this.fishList.Remove(fish);
                return true;
            }
            return false;
        }
    }
}
