using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split().ToArray();

                if (command.Contains("Change"))
                {
                    ChangeCommand(numbers, commandArr);
                }
                else if (command.Contains("Hide"))
                {
                    HideCommand(numbers, commandArr);
                }
                else if (command.Contains("Switch"))
                {
                    SwitchCommand(numbers, commandArr);
                }
                else if (command.Contains("Insert"))
                {
                    InsertCommand(numbers, commandArr);
                }
                else if (command.Contains("Reverse"))
                {
                    numbers.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }

        private static void InsertCommand(List<int> numbers, string[] commandArr)
        {
            int paintingToInsert = int.Parse(commandArr[2]);
            int indexToInsert = int.Parse(commandArr[1]);

            if (indexToInsert + 1 >= 0 && indexToInsert + 1 < numbers.Count)
            {
                numbers.Insert(indexToInsert + 1, paintingToInsert);
            }
        }

        private static void SwitchCommand(List<int> numbers, string[] commandArr)
        {
            int firstNumber = int.Parse(commandArr[1]);
            int secondNumber = int.Parse(commandArr[2]);

            if (numbers.Contains(firstNumber) && numbers.Contains(secondNumber))
            {
                int indexFirstNumber = numbers.IndexOf(firstNumber);
                int indexSecondNumber = numbers.IndexOf(secondNumber);
                int temp = numbers[indexFirstNumber];
                numbers[indexFirstNumber] = numbers[indexSecondNumber];
                numbers[indexSecondNumber] = temp;

            }
        }

        private static void HideCommand(List<int> numbers, string[] commandArr)
        {
            int value = int.Parse(commandArr[1]);
            if (numbers.Contains(value))
            {
                numbers.Remove(value);
            }
        }

        private static void ChangeCommand(List<int> numbers, string[] commandArr)
        {
            int number = int.Parse(commandArr[1]);
            int numberForChange = int.Parse(commandArr[2]);

            if (numbers.Contains(number))
            {
                int index = numbers.IndexOf(number);
                numbers[index] = numberForChange;
            }
        }
    }
}
