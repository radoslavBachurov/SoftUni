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
            int changes = ManipulatingList(numbers, command);

            if (changes > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static int ManipulatingList(List<int> numbers, string command)
        {
            int changes = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command.Contains("Add"))
                {
                    changes++;
                    ExecutingAddCommand(numbers, command);
                }
                else if (command.Contains("RemoveAt"))
                {
                    changes++;
                    ExecutingRemoveAtCommand(numbers, command);
                }
                else if (command.Contains("Remove"))
                {
                    changes++;
                    ExecutingRemoveCommand(numbers, command);
                }

                else if (command.Contains("Insert"))
                {
                    changes++;
                    ExecutingInsertCommand(numbers, command);
                }
                else if (command.Contains("PrintEven"))
                {
                    ExecutingPrintEvenCommand(numbers);
                }
                else if (command.Contains("PrintOdd"))
                {
                    ExecutingPrintOddCommand(numbers);
                }
                else if (command.Contains("GetSum"))
                {
                    Console.WriteLine($"{numbers.Sum()}");
                }
                else if (command.Contains("Filter"))
                {
                    ExecutingFilterCommand(command, numbers);
                }
                else if(command.Contains("Contains"))
                {
                    ExecutingContainsCommand(numbers, command);
                }
            }
            return changes;

        }

        private static void ExecutingPrintOddCommand(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                    Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }

        private static void ExecutingPrintEvenCommand(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                    Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }

        private static void ExecutingRemoveAtCommand(List<int> numbers, string command)
        {
            int number = 0;
            var strInt = command.Split().First(x => int.TryParse(x, out number));
            numbers.RemoveAt(number);
        }

        private static void ExecutingAddCommand(List<int> numbers, string command)
        {
            int number = 0;
            var strInt = command.Split().First(x => int.TryParse(x, out number));
            numbers.Add(number);
        }

        private static void ExecutingRemoveCommand(List<int> numbers, string command)
        {
            int number = 0;
            var strInt = command.Split().First(x => int.TryParse(x, out number));
            numbers.Remove(number);
        }

        private static void ExecutingContainsCommand(List<int> numbers, string command)
        {
            int number = 0;
            var strInt = command.Split().First(x => int.TryParse(x, out number));
            if (numbers.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void ExecutingInsertCommand(List<int> numbers, string command)
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

        private static void ExecutingFilterCommand(string command, List<int> numbers)
        {
            int number = 0;
            var strInt = command.Split().First(x => int.TryParse(x, out number));
            
            if (command.Contains(">="))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if(numbers[i]>=number)
                        Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine();
            }
            else if(command.Contains("<="))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= number)
                        Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine();
            }
            else if (command.Contains("<"))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < number)
                        Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine();
            }
            else if (command.Contains(">"))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > number)
                        Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
