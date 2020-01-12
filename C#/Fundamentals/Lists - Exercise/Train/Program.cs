using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = string.Empty;

            while((command=Console.ReadLine())!="end")
            {
                if(command.Contains("Add"))
                {
                    string resultString = Regex.Match(command, @"\d+").Value;
                    int number = Int32.Parse(resultString);
                    passengers.Add(number);
                }
                else
                {
                    int number = int.Parse(command);

                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if ((passengers[i] + number) <= maxCapacity)
                        {
                            passengers[i] += number;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",passengers));

        }
    }
}
