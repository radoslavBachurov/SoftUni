using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string arenaName)
        {
            gladiators = new List<Gladiator>();
            this.Name = arenaName;
        }
        public string Name { get; private set; }
        public int Count => this.gladiators.Count();

        public void Add(Gladiator newGladiator)
        {
            gladiators.Add(newGladiator);
        }

        public void Remove(string name)
        {
            if (gladiators.Any(x => x.Name == name))
            {
                Gladiator gladiatorToRemove = gladiators.Find(x => x.Name == name);

                gladiators.Remove(gladiatorToRemove);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator highest = gladiators[0];

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetStatPower() > highest.GetStatPower())
                {
                    highest = gladiators[i];
                }
            }

            return highest;
        }


        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator highest = gladiators[0];

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetWeaponPower() > highest.GetWeaponPower())
                {
                    highest = gladiators[i];
                }
            }

            return highest;
        }


        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator highest = gladiators[0];

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetTotalPower() > highest.GetTotalPower())
                {
                    highest = gladiators[i];
                }
            }

            return highest;
        }

        public override string ToString()
        {
            string toReturn = $"{this.Name} - {gladiators.Count} gladiators are participating.";
            return toReturn.Trim();
        }
    }
}
