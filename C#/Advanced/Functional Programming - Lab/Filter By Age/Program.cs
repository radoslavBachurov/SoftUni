using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                Person newPerson = new Person(input[0], int.Parse(input[1]));
                people.Add(newPerson);
            }

            string condition = Console.ReadLine();
            int ageBarrier = int.Parse(Console.ReadLine());
            Func<Person, bool> sortFunction;

            if(condition=="older")
            {
                sortFunction = x => x.Age >= ageBarrier;
            }
            else
            {
                sortFunction = x => x.Age <= ageBarrier;
            }

            string format = Console.ReadLine();
            string formatOrign = format;

            foreach (var person in people.Where(sortFunction))
            {
                if(format.Contains("name")&&format.Contains("age"))
                {
                    format = $"{person.Name} - {person.Age.ToString()}";
                }
                else
                {
                    format = format.Replace("age", person.Age.ToString()).Replace("name", person.Name);
                }
                Console.WriteLine(format);
                format = formatOrign;
            }

        }
    }
    class Person
    {
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
