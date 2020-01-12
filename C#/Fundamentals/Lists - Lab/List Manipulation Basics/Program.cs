using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string command = string.Empty;
            ManipulatingList(numbers, command);

            Console.WriteLine(string.Join(" ",numbers));
        }

        private static void ManipulatingList(List<int> numbers, string command)
        {
            while ((command = Console.ReadLine()) != "end")
            {
                if (command.Contains("Add"))
                {
                    int number = 0;
                    var strInt = command.Split().First(x => int.TryParse(x, out number));
                    numbers.Add(number);
                }
                else if (command.Contains("RemoveAt"))
                {
                    int number = 0;
                    var strInt = command.Split().First(x => int.TryParse(x, out number));
                    numbers.RemoveAt(number);
                }
                else if (command.Contains("Remove"))
                {
                    int number = 0;
                    var strInt = command.Split().First(x => int.TryParse(x, out number));
                    numbers.Remove(number);
                }
               
                else if (command.Contains("Insert"))
                {
                    int n = 0;
                    MatchCollection matches = Regex.Matches(command, @"[+-]?\d+(\.\d+)?");
                    int[] decimalarray = new int[matches.Count];

                    foreach (Match m in matches)
                    {
                        decimalarray[n] = int.Parse(m.Value);
                        n++;
                    }
                    numbers.Insert(decimalarray[1], decimalarray[0]);
                }
            }
            
        }
    }
}
