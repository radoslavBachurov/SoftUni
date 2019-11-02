namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentSystem
    {
        private List<Student> studentList;

        public StudentSystem()
        {
            this.studentList = new List<Student>();
        }

        public void Create(string name, string age, string grade)
        {
            if (!studentList.Any(x => x.Name == name))
            {
                int studentAge = int.Parse(age);
                double studentGrade = double.Parse(grade);
                studentList.Add(new Student(name, studentAge, studentGrade));
            }
        }

        public void Show(string name)
        {
            if (studentList.Any(x => x.Name == name))
            {
                Student studentToReturn = studentList.Find(x => x.Name == name);
                Console.WriteLine(studentToReturn.ToString());
            }
        }
    }
}