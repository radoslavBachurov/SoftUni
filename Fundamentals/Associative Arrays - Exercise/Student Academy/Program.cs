using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentList = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentList.ContainsKey(student))
                {
                    studentList.Add(student, new List<double>());
                }

                studentList[student].Add(grade);
            }

            Dictionary<string, List<double>> passedStudents = studentList
                .Where(x => x.Value.Average() >= 4.5).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in passedStudents.OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
