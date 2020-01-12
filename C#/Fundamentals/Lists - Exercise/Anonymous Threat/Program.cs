using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArr = command.Split();

                if (command.Contains("merge"))
                {
                    ExecutingMerge(input, commandArr);
                }
                else if (command.Contains("divide"))
                {
                    ExecutingDivide(input, commandArr);
                 }
            }
            Console.WriteLine(string.Join(" ", input));
 }

        private static void ExecutingDivide(List<string> input, string[] commandArr)
        {
            int leftIndex = int.Parse(commandArr[1]);
            int rightIndex = int.Parse(commandArr[2]);

            if (rightIndex == 0)
            {
                return;
            }

            string element = input[leftIndex];
            int partitionsLenght = input[leftIndex].Length / rightIndex;
            input.RemoveAt(leftIndex);
            string dividedElement = string.Empty;
            int dividedElementsAdded = 0;
            int counterLetters = 0;

            for (int i = 0; i < element.Length; i++)
            {

                dividedElement += element[i];
                counterLetters++;

                if (counterLetters % partitionsLenght == 0 && dividedElementsAdded <= rightIndex-1)
                {
                    input.Insert(leftIndex + dividedElementsAdded, dividedElement);
                    dividedElement = string.Empty;
                    dividedElementsAdded++;
                }
            }

            if (dividedElement.Length <= partitionsLenght)
            {
                string lastDividedElement = input[leftIndex + dividedElementsAdded-1];
                input.RemoveAt(leftIndex + dividedElementsAdded-1);
                lastDividedElement += dividedElement;
                input.Insert(leftIndex + dividedElementsAdded-1, lastDividedElement);
            }

        }

        private static void ExecutingMerge(List<string> input, string[] commandArr)
        {
            int leftIndex = int.Parse(commandArr[1]);
            int rightIndex = int.Parse(commandArr[2]);
            string concatenate = string.Empty;

            if ((leftIndex < 0 && rightIndex < 0) || (leftIndex >= input.Count && rightIndex >= input.Count))
            {
                return;
            }
            else if (leftIndex < 0 && rightIndex < input.Count)
            {
                for (int i = 0; i <= rightIndex; i++)
                {
                    concatenate += input[i];
                }
                input.RemoveRange(0, rightIndex + 1);
                input.Insert(0, concatenate);

            }
            else if (leftIndex >= 0 && rightIndex >= input.Count)
            {
                for (int i = leftIndex; i <= input.Count - 1; i++)
                {
                    concatenate += input[i];
                }
                input.RemoveRange(leftIndex, input.Count - leftIndex);
                input.Add(concatenate);
            }
            else if (leftIndex >= 0 && rightIndex < input.Count)
            {
                for (int i = leftIndex; i <= rightIndex; i++)
                {
                    concatenate += input[i];
                }
                input.RemoveRange(leftIndex, rightIndex - leftIndex + 1);
                input.Insert(leftIndex, concatenate);
            }
            else if (leftIndex < 0 && rightIndex >= input.Count)
            {
                concatenate = string.Join("", input);
                input.RemoveRange(0, input.Count);
                input.Add(concatenate);
            }

        }
    }
}
