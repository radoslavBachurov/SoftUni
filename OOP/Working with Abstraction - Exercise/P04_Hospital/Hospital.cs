using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Hospital
    {
        private Dictionary<string, Department> departments;
        private List<Doctor> doctors;

        public Hospital()
        {
            this.doctors = new List<Doctor>();
            this.departments = new Dictionary<string, Department>();
        }

        public void AddingPatients(string departament, string patient, string fullName)
        {
            if (!this.doctors.Any(x => x.Name == fullName))
            {
                Doctor newDoctor = new Doctor(fullName);
                doctors.Add(newDoctor);
            }

            if (!this.departments.ContainsKey(departament))
            {
                Department newDepartment = new Department();
                departments.Add(departament, newDepartment);
            }

            if (this.departments[departament].freePlace())
            {
                Doctor doctorToFind = this.doctors.Find(x => x.Name == fullName);
                doctorToFind.AddPatient(patient);
                this.departments[departament].AddPatient(patient);
            }
        }

        public Department GetDepartment(string name)
        {
            return departments[name];
        }

        public Doctor GetDoctor(string name)
        {
            return doctors.Find(x => x.Name == name);
        }
    }


}
