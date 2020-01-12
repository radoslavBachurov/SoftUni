using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name,Stat stat,Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int sum = Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength
                + Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
            return sum;
        }

        public int GetStatPower()
        {
            int sum = Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;
            return sum;
        }

        public int GetWeaponPower()
        {
            int sum = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
            return sum;
        }

        public override string ToString()
        {
                     
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"{this.Name} - {GetTotalPower()}");
            newSB.AppendLine($"Weapon Power: {GetWeaponPower()}");
            newSB.Append($"Stat Power: {GetStatPower()}");

            return newSB.ToString().Trim();
        }
    }
}
