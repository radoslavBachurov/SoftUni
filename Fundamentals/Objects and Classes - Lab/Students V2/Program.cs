using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Student> studentArchive = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split().ToArray();

                CreatingStudentsList(studentArchive, commandArr);
            }

            string town = Console.ReadLine();

            printStudents(town, studentArchive);

        }

        private static void CreatingStudentsList(List<Student> studentArchive, string[] commandArr)
        {
            Student students = new Student();

            students.firstName = commandArr[0];
            students.lastName = commandArr[1];
            students.age = commandArr[2];
            students.homeTown = commandArr[3];

            if (studentArchive.Count == 0)
            {
                studentArchive.Add(students);
                return;
            }

            bool repeatedStudent = true;
            for (int i = 0; i < studentArchive.Count; i++)
            {
                if (studentArchive[i].firstName == commandArr[0]
                   && studentArchive[i].lastName == commandArr[1])
                {
                    studentArchive.RemoveAt(i);
                    studentArchive.Insert(i, students);
                    repeatedStudent = false;
                }
            }

            if (repeatedStudent)
            {
                studentArchive.Add(students);
            }
        }

        private static void printStudents(string town, List<Student> studentArchive)
        {
            List<Student> sortedStudents = studentArchive
                .Where(students => students.homeTown == town).ToList();

            foreach (Student item in sortedStudents)
            {
                Console.WriteLine($"{item.firstName} {item.lastName} is {item.age} years old.");
            }

        }
    }
    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public string homeTown { get; set; }
    }
}
