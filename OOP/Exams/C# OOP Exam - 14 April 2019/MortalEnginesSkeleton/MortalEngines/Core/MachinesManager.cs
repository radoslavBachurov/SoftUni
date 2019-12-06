﻿namespace MortalEngines.Core
{
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;
    using System.Linq;
    using MortalEngines.Machines;
    using MortalEngines.Common;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            var newPilot = new Pilot(name);
            pilots.Add(newPilot);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine newTank = new Tank(name, attackPoints, defensePoints);
            machines.Add(newTank);
            return $"Tank {name} manufactured - attack: {newTank.AttackPoints:f2}; defense: {newTank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine newFighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(newFighter);
            return $"Fighter {name} manufactured - attack: {newFighter.AttackPoints:f2}; defense: {newFighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (pilots.Any(x => x.Name == selectedPilotName))
            {
                if (machines.Any(x => x.Name == selectedMachineName))
                {
                    var machine = machines.First(x => x.Name == selectedMachineName);
                    var pilot = pilots.First(x => x.Name == selectedPilotName);

                    if (machine.Pilot == null)
                    {
                        pilot.AddMachine(machine);
                        machine.Pilot = pilot;
                        return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
                    }

                    return $"Machine {selectedMachineName} is already occupied";
                }

                return $"Machine {selectedMachineName} could not be found";
            }

            return $"Pilot {selectedPilotName} could not be found";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (machines.Any(x => x.Name == attackingMachineName))
            {
                if (machines.Any(x => x.Name == defendingMachineName))
                {
                    var atacker = machines.First(x => x.Name == attackingMachineName);
                    var defender = machines.First(x => x.Name == defendingMachineName);

                    if (atacker.HealthPoints > 0)
                    {
                        if (defender.HealthPoints > 0)
                        {
                            atacker.Attack(defender);

                            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defender.HealthPoints:F2}";
                        }

                        return $"Dead machine {defendingMachineName} cannot attack or be attacked";
                    }

                    return $"Dead machine {attackingMachineName} cannot attack or be attacked";
                }

                return $"Machine {defendingMachineName} could not be found";
            }

            return $"Machine {attackingMachineName} could not be found";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotInfo = pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilotInfo.Report();
        }

        public string MachineReport(string machineName)
        {
            var machineInfo = machines.FirstOrDefault(x => x.Name == machineName);

            return machineInfo.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (machines.Any(x => x.Name == fighterName))
            {
                var fighter = (Fighter)machines.First(x => x.Name == fighterName);
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (machines.Any(x => x.Name == tankName))
            {
                var tank = (Tank)machines.First(x => x.Name == tankName);
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }

            return $"Machine {tankName} could not be found";
        }
    }
}