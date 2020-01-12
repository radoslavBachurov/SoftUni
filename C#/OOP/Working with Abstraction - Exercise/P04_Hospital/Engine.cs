using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital newHospital;
        public Engine()
        {
            newHospital = new Hospital();
        }

        public void Run()
        {
            string patientInfo = string.Empty;
            while ((patientInfo = Console.ReadLine()) != "Output")
            {
                string[] inputArr = patientInfo.Split();
                var departament = inputArr[0];
                var patient = inputArr[3];
                var fullName = inputArr[1] + inputArr[2];

                newHospital.AddingPatients(departament,patient,fullName);
            }

            Printing(newHospital);
        }

        private static void Printing(Hospital newHospital)
        {
            string infoToShow = string.Empty;
            while ((infoToShow = Console.ReadLine()) != "End")
            {
                string[] infoToShowArr = infoToShow.Split();

                if (infoToShowArr.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", newHospital.GetDepartment(infoToShowArr[0])));
                }
                else if (infoToShowArr.Length == 2 && int.TryParse(infoToShowArr[1], out int room))
                {
                    Console.WriteLine(newHospital.GetDepartment(infoToShowArr[0]).GetRoom(room).ToString());
                }
                else
                {
                    Console.WriteLine(newHospital.GetDoctor(infoToShowArr[0] + infoToShowArr[1]).ToString());
                }

            }
        }
    }
}
