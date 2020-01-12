using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Cataloque personList = new Cataloque();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person man = new Person(inputArr[0], inputArr[1], int.Parse(inputArr[2]));
                personList.People.Add(man);
            }

            personList.People = personList.People.OrderBy(x => x.Age).ToList();

            foreach (var item in personList.People)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
    }
    class Person
    {
        public Person(string name, string id, int age)
        {
             Name = name;
             ID = id;
             Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class Cataloque
    {
        public Cataloque()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }
    }
}
