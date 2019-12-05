using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Machines
{
    public class Pilot : IPilot
    {
        private string name;

        public Pilot(string name)
        {
            this.name = name;
            this.Machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public IList<IMachine> Machines { get; private set; }

        public void AddMachine(IMachine machine)
        {
            if (machine is null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.Machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder newSb = new StringBuilder();

            newSb.AppendLine($"{this.name} - {this.Machines.Count} machines");

            foreach (var machine in this.Machines)
            {
                newSb.AppendLine($"- {machine.Name}");
                newSb.AppendLine($" *Type: {GetType().Name}");
                newSb.AppendLine($" *Health: {machine.HealthPoints}");
                newSb.AppendLine($" *Attack: {machine.AttackPoints}");
                newSb.AppendLine($" *Defense: {machine.DefensePoints}");
                newSb.AppendLine($" *Targets: {machine.Targets.Count}");
            }

            return newSb.ToString().Trim();
        }
    }
}
