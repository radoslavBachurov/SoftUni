using System;
using System.Collections.Generic;
using System.Linq;

namespace First_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split().ToArray();

                if (commandArr.Contains("Switch"))
                {
                    ExecutingSwitchCommand(numbers, commandArr);
                }
                else if (commandArr.Contains("Change"))
                {
                    ExecutingChangeCommand(numbers, commandArr);
                }
                else if (commandArr.Contains("Negative"))
                {
                    ExecutingNegativeComand(commandArr, numbers);
                }
                else if (commandArr.Contains("Positive"))
                {
                    ExecutingSumPositiveCommand(numbers, commandArr);
                }
                else if (commandArr.Contains("All"))
                {
                    Console.WriteLine(numbers.Sum());
                }
            }

            List<double> printPositive = new List<double>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i]==0||numbers[i]>0)
                {
                    printPositive.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ",printPositive));
        }

        private static void ExecutingSumPositiveCommand(List<double> numbers, string[] commandArr)
        {
            double sumPositive = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    sumPositive += numbers[i];
                }
            }

            Console.WriteLine(sumPositive);
        }

        private static void ExecutingNegativeComand(string[] commandArr, List<double> numbers)
        {
            double sumNegative = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    sumNegative += numbers[i];
                }
            }

            Console.WriteLine(sumNegative);
        }

        private static void ExecutingChangeCommand(List<double> numbers, string[] commandArr)
        {
            int index = int.Parse(commandArr[1]);
            double number = double.Parse(commandArr[2]);

            if (index >= 0 && index < numbers.Count)
            {
                numbers[index] = number;
            }
        }

        private static void ExecutingSwitchCommand(List<double> numbers, string[] commandArr)
        {
            int index = int.Parse(commandArr[1]);

            if (index >= 0 && index < numbers.Count)
            {

                if (numbers[index] < 0)
                {
                    numbers[index] = Math.Abs(numbers[index]);
                }
                else if (numbers[index] > 0)
                {
                    numbers[index] = numbers[index] * (-1);
                }
            }
        }
    }
}
