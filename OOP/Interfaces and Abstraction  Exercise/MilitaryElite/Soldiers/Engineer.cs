using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Part> parts;
        public Engineer(string id, string firstName, string lastName, string corps, decimal salary)
            : base(id, firstName, lastName, corps, salary)
        {
            parts = new List<Part>();
        }

        public IReadOnlyCollection<Part> Parts => this.parts;

        public void AddPart(string name, double hours)
        {
            this.parts.Add(new Part(name, hours));
        }

        public override string ToString()
        {
            var newSb = new StringBuilder();
            newSb.AppendLine($"{base.ToString()}");
            newSb.AppendLine("Repairs:");
            foreach (var newPart in this.parts)
            {
                newSb.AppendLine($"  {newPart.ToString()}");
            }
            return newSb.ToString().Trim();
        }
    }
}
