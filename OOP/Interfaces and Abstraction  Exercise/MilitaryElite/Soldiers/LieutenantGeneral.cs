using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class LieutenantGeneral : Soldier , ILieutenantGeneral,ISoldier
    {
        HashSet<IPrivate> listOfPrivates;
        public LieutenantGeneral(string id, string firstName, string lastName,decimal salary)
                   : base(id, firstName, lastName)
        {
            this.Salary = salary;
            listOfPrivates = new HashSet<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> ListOfPrivates => this.listOfPrivates;

        public decimal Salary { get; private set; }

        public void AddPrivate(IPrivate newPrivate)
        {
            this.listOfPrivates.Add(newPrivate);
        }

        public override string ToString()
        {
            var newSb = new StringBuilder();
            newSb.AppendLine($"{base.ToString()}Salary: {this.Salary:f2}");
            newSb.AppendLine("Privates:");
            foreach (var newPrivate in this.listOfPrivates)
            {
                newSb.AppendLine($"  {newPrivate.ToString()}");
            }
            return newSb.ToString().Trim();
        }
    }
}
