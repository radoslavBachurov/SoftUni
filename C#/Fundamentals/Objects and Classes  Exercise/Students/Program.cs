using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            StudentList firstListStudents = new StudentList();

            for (int i = 0; i < countStudents; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Student studentInfo = new Student(input[0], input[1], double.Parse(input[2]));
                firstListStudents.FirstListStudents.Add(studentInfo);
            }

            
            foreach (var student in firstListStudents.FirstListStudents.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            string toPrint = $"{FirstName} {LastName}: {Grade:f2}";
            return toPrint;
        }


    }
    class StudentList
    {
        public StudentList()
        {
            FirstListStudents = new List<Student>();
        }
        public List<Student> FirstListStudents { get; set; }
    }
}
