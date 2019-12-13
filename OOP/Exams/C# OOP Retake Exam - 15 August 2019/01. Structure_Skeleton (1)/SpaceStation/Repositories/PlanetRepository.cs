using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository
    {
        private List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planetToReturn = this.models.Find(x => x.Name == name);
            return planetToReturn;
        }

        public bool Remove(IPlanet model)
        {
            if(this.models.Any(x=>x.Name==model.Name))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
