using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private const int capacity = 3;
        private List<string> patients;

        public Room()
        {
            this.patients = new List<string>();
        }

        public int PatientCount => this.patients.Count;

        public bool freePlace()
        {
            if (this.patients.Count == capacity)
            {
                return false;
            }
            return true;
        }

        public void AddPatient(string patient)
        {
            this.patients.Add(patient);
        }

        public List<string> GetPatients()
        {
            return patients;
        }

        public override string ToString()
        {
            string toReturn = string.Join("\n", patients.OrderBy(x => x)).TrimEnd();

            return toReturn;
        }
    }
}
