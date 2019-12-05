using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Machines
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 100)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine(base.ToString());

            if (DefenseMode)
            {
                newSB.AppendLine($" *Defense: ON");
            }
            else
            {
                newSB.AppendLine($" *Defense: OFF");
            }

            return newSB.ToString().Trim();
        }
    }
}
