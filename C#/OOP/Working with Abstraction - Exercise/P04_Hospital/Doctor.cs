using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private List<string> patients;

        public Doctor(string name)
        {
            this.patients = new List<string>();
            this.Name = name;
        }

        public string Name { get; private set; }

        public void AddPatient(string patient)
        {
            this.patients.Add(patient);
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            foreach (var item in patients.OrderBy(x => x))
            {
                newSB.AppendLine(item);
            }
            return newSB.ToString().Trim();
        }
    }
}
