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

                Student students = new Student();

                students.firstName = commandArr[0];
                students.lastName = commandArr[1];
                students.age = commandArr[2];
                students.homeTown = commandArr[3];

                studentArchive.Add(students);
            }

            string town = Console.ReadLine();

            printStudents(town, studentArchive);

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
