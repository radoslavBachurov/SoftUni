using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var newSb = new StringBuilder();
            newSb.AppendLine($"{base.ToString()}");
            newSb.Append($"Code Number: {this.CodeNumber}");
            return newSb.ToString().Trim();
        }
    }
}
