using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{


    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                var newFresh = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(newFresh);
                return string.Format(OutputMessages.SuccessfullyAdded, newFresh.GetType().Name);
            }
            else
            {
                var newFresh = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(newFresh);
                return string.Format(OutputMessages.SuccessfullyAdded, newFresh.GetType().Name);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
            if (decorationType == "Ornament")
            {
                var newFresh = new Ornament();
                this.decorations.Add(newFresh);
                return string.Format(OutputMessages.SuccessfullyAdded, newFresh.GetType().Name);
            }
            else
            {
                var newFresh = new Plant();
                this.decorations.Add(newFresh);
                return string.Format(OutputMessages.SuccessfullyAdded, newFresh.GetType().Name);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            var newFish = new FreshwaterFish(fishName, fishSpecies, price);

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                aquarium.AddFish(newFish);
                return string.Format(OutputMessages.FishAdded, fishType, aquariumName);
            }
            else if ((aquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish"))
            {
                aquarium.AddFish(newFish);
                return string.Format(OutputMessages.FishAdded, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            decimal sumFish = 0;
            decimal sumdeco = 0;

            foreach (var item in aquarium.Fish)
            {
                sumFish += item.Price;
            }

            foreach (var item in aquarium.Decorations)
            {
                sumdeco += item.Price;
            }
            decimal sumall = sumdeco + sumFish;
            return string.Format(OutputMessages.AquariumValue, aquariumName, sumall);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {

            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);

        }

        public string Report()
        {
            StringBuilder newSB = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                newSB.Append($"{aquarium.GetInfo()}\r\n");
            }

            return newSB.ToString().TrimEnd();
        }
    }
}
