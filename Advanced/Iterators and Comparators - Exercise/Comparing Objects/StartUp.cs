using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personList = new List<Person>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = inputArr[0];
                int age = int.Parse(inputArr[1]);
                string town = inputArr[2];

                var newPerson = new Person(name, age, town);
                personList.Add(newPerson);
            }

            var personToCompare = personList[int.Parse(Console.ReadLine()) - 1];

            var listOfEqual = new List<Person>();
            var listOfUnequal = new List<Person>();

            for (int i = 0; i < personList.Count; i++)
            {
                if (personToCompare.CompareTo(personList[i]) == 0)
                {
                    listOfEqual.Add(personList[i]);
                }
                else
                {
                    listOfUnequal.Add(personList[i]);
                }
            }

            if (listOfEqual.Count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{listOfEqual.Count} {listOfUnequal.Count} {personList.Count}");
            }
        }
    }
}
