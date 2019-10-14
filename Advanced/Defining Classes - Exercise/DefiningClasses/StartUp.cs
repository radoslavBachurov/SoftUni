using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family familyList = new Family();

            for (int i = 0; i < count; i++)
            {
                string[] inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Person newPerson = new Person(inputArr[0], int.Parse(inputArr[1]));
                familyList.AddMember(newPerson);
            }

            List<Person> olderThanThirty = familyList.ListOfPeople.Where(x => x.Age > 30).ToList();

            foreach (Person person in olderThanThirty.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
