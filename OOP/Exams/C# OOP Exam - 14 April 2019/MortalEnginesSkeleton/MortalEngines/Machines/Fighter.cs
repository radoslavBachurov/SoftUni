using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 200)
        {
            ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine(base.ToString());

            if (AggressiveMode)
            {
                newSB.AppendLine($" *Aggressive: ON");
            }
            else
            {
                newSB.AppendLine($" *Aggressive: OFF");
            }

            return newSB.ToString().Trim();
        }
    }
}
