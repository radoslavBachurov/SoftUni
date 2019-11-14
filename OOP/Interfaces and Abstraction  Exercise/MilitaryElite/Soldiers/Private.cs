using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class Private : Soldier, ISoldier, IPrivate
    {
        public Private(string id, string firstName, string lastName,decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            string toReturn = $"{base.ToString()}Salary: {this.Salary:f2}";
            return toReturn;
        }
    }
}
