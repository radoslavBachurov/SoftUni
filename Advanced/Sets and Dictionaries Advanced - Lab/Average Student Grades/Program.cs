using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> namesAndGrade = new Dictionary<string, List<double>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!namesAndGrade.ContainsKey(name))
                {
                    namesAndGrade.Add(name, new List<double>());
                }

                namesAndGrade[name].Add(grade);
            }

            foreach (var item in namesAndGrade)
            {
                Console.WriteLine($"{item.Key} -> " +
                    $"{string.Join(" ", item.Value.Select(x=>x.ToString("F2")))}" +
                    $" (avg: {item.Value.Average():f2})");
            }
        }
    }
}
