using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorRepo;
        private IRepository<IRace> raceRepo;
        private IRepository<IRider> riderRepo;

        public ChampionshipController()
        {
        }

        public ChampionshipController(IRepository<IMotorcycle> motorRepo,
                                      IRepository<IRace> raceRepo,
                                      IRepository<IRider> riderRepo)
        {
            this.motorRepo = motorRepo;
            this.raceRepo = raceRepo;
            this.riderRepo = riderRepo;
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var listOfMotors = motorRepo.GetAll().ToList();
            var listOfRiders = riderRepo.GetAll().ToList();

            if (!listOfRiders.Any(x => x.Name == riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));

            }

            if (!listOfMotors.Any(x => x.Model == motorcycleModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));

            }

            var rider = riderRepo.GetByName(riderName);
            var motor = motorRepo.GetByName(motorcycleModel);

            rider.AddMotorcycle(motor);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var listOfRaces = raceRepo.GetAll().ToList();
            var listOfRiders = riderRepo.GetAll().ToList();

            if (!listOfRaces.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            }

            if (!listOfRiders.Any(x => x.Name == riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));

            }

            var race = raceRepo.GetByName(raceName);
            var rider = riderRepo.GetByName(riderName);
            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var listOfMotors = motorRepo.GetAll().ToList();
            if (listOfMotors.Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Speed")
            {
                var newMotorycle = new SpeedMotorcycle(model, horsePower);
                motorRepo.Add(newMotorycle);
                return string.Format(OutputMessages.MotorcycleCreated, newMotorycle.GetType().Name, model);
            }
            else
            {
                var newMotorycle = new PowerMotorcycle(model, horsePower);
                motorRepo.Add(newMotorycle);
                return string.Format(OutputMessages.MotorcycleCreated, newMotorycle.GetType().Name, model);
            }
        }

        public string CreateRace(string name, int laps)
        {
            var listOfRaces = raceRepo.GetAll().ToList();
            if (listOfRaces.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var newRace = new Race(name, laps);
            raceRepo.Add(newRace);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            IRider newRider = new Rider(riderName);
            var listOfRiders = riderRepo.GetAll().ToList();

            if (listOfRiders.Any(x => x.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            riderRepo.Add(newRider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var listOfRaces = raceRepo.GetAll().ToList();

            if (!listOfRaces.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var race = raceRepo.GetByName(raceName);
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var newSB = new StringBuilder();

            int count = 0;
            foreach (var rider in race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                if (count == 0)
                {
                    newSB.AppendLine(string.Format(OutputMessages.RiderFirstPosition, rider.Name, raceName));
                }
                else if (count == 1)
                {
                    newSB.AppendLine(string.Format(OutputMessages.RiderSecondPosition, rider.Name, raceName));
                }
                else if (count == 2)
                {
                    newSB.AppendLine(string.Format(OutputMessages.RiderThirdPosition, rider.Name, raceName));
                }
                count++;
                if (count == 3)
                {
                    break;
                }
            }
            raceRepo.Remove(race);
            return newSB.ToString().TrimEnd();
        }
    }
}
