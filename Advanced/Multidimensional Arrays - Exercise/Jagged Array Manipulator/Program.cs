using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());

            double[][] jaggedIntMatrix = new double[numberRows][];

            for (int i = 0; i < numberRows; i++)
            {
                double[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedIntMatrix[i] = input;

                if (i > 0)
                {
                    TakingInput(jaggedIntMatrix, i);
                }
            }

            ExecutingCommands(numberRows, jaggedIntMatrix);

            Printing(jaggedIntMatrix);
            return;
        }

        private static void Printing(double[][] jaggedIntMatrix)
        {
            foreach (var item in jaggedIntMatrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        private static void ExecutingCommands(int numberRows, double[][] jaggedIntMatrix)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()?.ToLower()) != "end")
            {
                string[] commandArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string operation = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int collum = int.Parse(commandArr[2]);
                int value = int.Parse(commandArr[3]);

                bool indexValidation = row >= 0 &&
                    row < numberRows &&
                    collum >= 0 &&
                    collum < jaggedIntMatrix[row].Length;

                if (operation.ToLower() == "add" && indexValidation)
                {
                    jaggedIntMatrix[row][collum] += value;
                }
                else if (operation.ToLower() == "subtract" && indexValidation)
                {
                    jaggedIntMatrix[row][collum] -= value;
                }
            }
        }

        private static void TakingInput(double[][] jaggedIntMatrix, int i)
        {
            if (jaggedIntMatrix[i].Length == jaggedIntMatrix[i - 1].Length)
            {
                for (int t = 0; t < jaggedIntMatrix[i].Length; t++)
                {
                    jaggedIntMatrix[i][t] *= 2.0;
                    jaggedIntMatrix[i - 1][t] *= 2.0;
                }
            }
            else
            {
                for (int t = 0; t < jaggedIntMatrix[i].Length; t++)
                {
                    jaggedIntMatrix[i][t] /= 2.0;
                }
                for (int t = 0; t < jaggedIntMatrix[i - 1].Length; t++)
                {
                    jaggedIntMatrix[i - 1][t] /= 2.0;
                }
            }
        }
    }
}

