using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astrRepo;
        private PlanetRepository planetRepo;
        private IMission newMission;
        private int planetExplored;

        public Controller()
        {
            this.astrRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            newMission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (!AstronautValidatorType.ValidateAstronautType(type))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            var newAstronaut = AstronautFactory.CreateAstronaut(type, astronautName);
            astrRepo.Add(newAstronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet newPlanet = new Planet(planetName);

            foreach (var item in items)
            {
                newPlanet.Items.Add(item);
            }

            planetRepo.Add(newPlanet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (!this.astrRepo.Models.Any(x => x.Oxygen > 60))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }

            var planetToExplore = planetRepo.FindByName(planetName);

            if(planetToExplore is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidPlanetName);
            }

            newMission.Explore(planetToExplore, (ICollection<IAstronaut>)astrRepo.Models);

            var deadAstr = astrRepo.Models.Where(x => x.Oxygen <= 0);

            if (!planetToExplore.Items.Any())
            {
                this.planetRepo.Remove(planetToExplore);
                this.planetExplored++;
            }

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstr.Count());
        }

        public string Report()
        {
            StringBuilder newSB = new StringBuilder();

            newSB.Append($"{this.planetExplored} planets were explored!\r\n");
            newSB.Append("Astronauts info:\r\n");

            foreach (var item in astrRepo.Models)
            {
                newSB.Append($"{item.ToString()}\r\n");
            }

            return newSB.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astrToRemove = this.astrRepo.FindByName(astronautName);

            if (astrToRemove is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            else
            {
                this.astrRepo.Remove(astrToRemove);
            }

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
