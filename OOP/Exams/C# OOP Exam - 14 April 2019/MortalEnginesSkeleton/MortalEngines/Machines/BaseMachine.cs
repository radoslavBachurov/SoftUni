using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double difference = this.AttackPoints - target.DefensePoints;
            double targetNewHealth = target.HealthPoints - difference;

            if (targetNewHealth < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= difference;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"- {this.name}");
            newSB.AppendLine($" *Type: {GetType().Name}");
            newSB.AppendLine($" *Health: {this.HealthPoints:f2}");
            newSB.AppendLine($" *Attack: {this.AttackPoints:f2}");
            newSB.AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (Targets.Count == 0)
            {
                newSB.AppendLine($" *Targets: None");
            }
            else
            {
                foreach (var item in Targets)
                {
                    newSB.AppendLine($" *Targets: {string.Join(",", Targets)}");
                }
            }

            return newSB.ToString().Trim();
        }
    }
}
