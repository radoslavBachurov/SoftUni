using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSizes = int.Parse(Console.ReadLine());

            int[,] newMatrix = new int[matrixSizes, matrixSizes];

            for (int i = 0; i < matrixSizes; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse).ToArray();

                for (int t = 0; t < matrixSizes; t++)
                {
                    newMatrix[i, t] = numbers[t];
                }
            }

            int sum = 0;
            for (int i = 0; i < matrixSizes; i++)
            {
                sum += newMatrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
