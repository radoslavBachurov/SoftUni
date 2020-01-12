using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] newMatrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int t = 0; t < matrixSize; t++)
                {
                    newMatrix[i, t] = input[t];
                }
            }

            int sumPrimary = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                sumPrimary += newMatrix[i, i];
            }

            int sumSecondary = 0;
            int count = 0;
            for (int i = matrixSize - 1; i >= 0; i--)
            {
                sumSecondary += newMatrix[count, i];
                count++;
            }

            Console.WriteLine($"{Math.Abs(sumPrimary - sumSecondary)}");
        }
    }
}
