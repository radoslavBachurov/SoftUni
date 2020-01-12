using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] charMatrix = new char[rowsColls[0], rowsColls[1]];

            for (int i = 0; i < rowsColls[0]; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < rowsColls[1]; j++)
                {
                    charMatrix[i, j] = input[j];
                }
            }

            int count = 0;
            for (int i = 0; i < rowsColls[0] - 1; i++)
            {
                for (int k = 0; k < rowsColls[1] - 1; k++)
                {
                    bool equals = charMatrix[i, k] == charMatrix[i, k + 1] &&
                        charMatrix[i + 1, k] == charMatrix[i + 1, k + 1] &&
                        charMatrix[i, k] == charMatrix[i + 1, k + 1];

                    if(equals)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
