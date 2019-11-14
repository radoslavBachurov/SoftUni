using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class Spy : Soldier, ISpy, ISoldier
    {
        public Spy(string id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
        }

        public int codeNumber { get; private set; }

        public override string ToString()
        {
            var newSb = new StringBuilder();
            newSb.AppendLine($"{base.ToString()}");
            newSb.Append($"Code Number: {this.codeNumber}");
            return newSb.ToString().Trim();
        }
    }
}
