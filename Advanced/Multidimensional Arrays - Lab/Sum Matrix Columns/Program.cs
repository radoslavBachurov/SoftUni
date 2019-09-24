using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] newMatrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse).ToArray();

                for (int t = 0; t < matrixSizes[1]; t++)
                {
                    newMatrix[i, t] = numbers[t];
                }
            }

            for (int i = 0; i < matrixSizes[1]; i++)
            {
                int sum = 0;

                for (int t = 0; t < matrixSizes[0]; t++)
                {
                    sum += newMatrix[t, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
