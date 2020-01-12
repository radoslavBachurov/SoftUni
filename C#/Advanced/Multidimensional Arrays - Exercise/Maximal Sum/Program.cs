using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColls = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[,] intMatrix = new int[rowsColls[0], rowsColls[1]];

            for (int i = 0; i < rowsColls[0]; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < rowsColls[1]; j++)
                {
                    intMatrix[i, j] = input[j];
                }
            }

            int max = int.MinValue;
            int indexRow = -1;
            int indexCol = -1;
            for (int i = 0; i < rowsColls[0] - 2; i++)
            {
                for (int j = 0; j < rowsColls[1] - 2; j++)
                {
                    int sum = intMatrix[i, j] + intMatrix[i, j + 1] + intMatrix[i, j + 2]
                        + intMatrix[i + 1, j] + intMatrix[i + 1, j + 1] + intMatrix[i + 1, j + 2]
                        + intMatrix[i + 2, j] + intMatrix[i + 2, j + 1] + intMatrix[i + 2, j + 2];

                    if (sum > max)
                    {
                        max = sum;
                        indexRow = i;
                        indexCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {max}");
            Console.WriteLine($"{intMatrix[indexRow, indexCol]} {intMatrix[indexRow, indexCol + 1]} {intMatrix[indexRow, indexCol + 2]}");
            Console.WriteLine($"{intMatrix[indexRow + 1, indexCol]} {intMatrix[indexRow + 1, indexCol + 1]} {intMatrix[indexRow + 1, indexCol + 2]}");
            Console.WriteLine($"{intMatrix[indexRow + 2, indexCol]} {intMatrix[indexRow + 2, indexCol + 1]} {intMatrix[indexRow + 2, indexCol + 2]}");

        }
    }
}
