using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var HashSet = new HashSet<Person>();
            var SortedSet = new SortedSet<Person>();
            

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                var newPerson = new Person(name,age);
                HashSet.Add(newPerson);
                SortedSet.Add(newPerson);
            }

            Console.WriteLine($"{HashSet.Count}");
            Console.WriteLine($"{SortedSet.Count}");
        }
    }
}
