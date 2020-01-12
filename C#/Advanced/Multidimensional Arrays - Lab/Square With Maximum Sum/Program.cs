using System;
using System.Linq;

namespace Square_With_Maximum_Sum
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
                int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int t = 0; t < matrixSizes[1]; t++)
                {
                    newMatrix[i, t] = numbers[t];
                }
            }

            
            int max = int.MinValue;
            int maxIndexRow = -1;
            int maxIndexCol = -1;

            for (int i = 0; i < matrixSizes[0]-1; i++)
            {
                for (int t = 0; t < matrixSizes[1]-1; t++)
                {
                    int sum = newMatrix[i, t] + newMatrix[i + 1, t] +
                        newMatrix[i, t + 1] + newMatrix[i + 1, t + 1];

                    if (sum > max)
                    {
                        max = sum;
                        maxIndexRow = i;
                        maxIndexCol = t;
                    }

                }
            }

            Console.WriteLine($"{newMatrix[maxIndexRow,maxIndexCol]} {newMatrix[maxIndexRow,maxIndexCol+1]}");
            Console.WriteLine($"{newMatrix[maxIndexRow+1,maxIndexCol]} {newMatrix[maxIndexRow+1,maxIndexCol+1]}");
            Console.WriteLine($"{max}");
        }
    }
}
