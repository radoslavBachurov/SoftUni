using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath || planet.Items.Count > 0)
                {
                    string toAdd = planet.Items.First();

                    astronaut.Bag.Items.Add(toAdd);
                    planet.Items.Remove(toAdd);

                    astronaut.Breath();
                }
            }
        }
    }
}
