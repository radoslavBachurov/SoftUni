using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository
    {
        private List<IAstronaut> models;
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {

            var astronautToReturn = this.models.Find(x => x.Name == name);
            return astronautToReturn;
        }

        public bool Remove(IAstronaut model)
        {
            if (this.models.Any(x => x.Name == model.Name))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
