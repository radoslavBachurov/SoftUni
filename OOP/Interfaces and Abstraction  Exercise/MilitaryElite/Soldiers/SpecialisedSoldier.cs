﻿using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier,ISoldier
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, string corps, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Corps = corps;
            this.Salary = salary;
        }

        public string Corps
        {
            get => this.corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Not Existing Corpse");
                }
            }
        }

        public decimal Salary { get; private set; }
    }
}
