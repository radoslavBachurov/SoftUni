using System;
using System.Collections.Generic;
using System.Linq;

namespace Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family newFamily = new Family();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                int age = int.Parse(input[1]);
                string name = input[0];

                Person newPerson = new Person(name,age);
                newFamily.AddMember(newPerson);
            }

            Person oldest = newFamily.GetOlderstMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
    class Family
    {
        public Family()
        {
            MyFamily = new List<Person>();
        }
        public List<Person> MyFamily { get; set; }

        public void AddMember(Person newMember)
        {
            MyFamily.Add(newMember);
        }

        public Person GetOlderstMember()
        {
            Person oldest = MyFamily.OrderByDescending(x => x.Age).First();
            return oldest;
        }
    }
    class Person
    {
        public Person(string name,int age)
        {
            Name = name;
            Age = age; ;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
