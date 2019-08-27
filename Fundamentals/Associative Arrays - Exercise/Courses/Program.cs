using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var coursesStrudentList = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split(" : ").ToArray();
                string course = commandArr[0];
                string student = commandArr[1];

                if (!coursesStrudentList.ContainsKey(course))
                {
                    coursesStrudentList.Add(course, new List<string>());
                }

                coursesStrudentList[course].Add(student);
            }

            Printing(coursesStrudentList);
        }

        private static void Printing(Dictionary<string, List<string>> coursesStrudentList)
        {
            foreach (var item in coursesStrudentList.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var student in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
