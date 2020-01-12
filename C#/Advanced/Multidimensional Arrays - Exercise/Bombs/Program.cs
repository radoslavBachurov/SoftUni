using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] bombField = new int[matrixSize, matrixSize];

            CreatinField(matrixSize, bombField);
            BlowingUpBombs(matrixSize, bombField);
            Printing(matrixSize, bombField);
        }

        private static void Printing(int matrixSize, int[,] bombField)
        {
            int sum = 0;
            int count = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int t = 0; t < matrixSize; t++)
                {
                    if (bombField[i, t] > 0)
                    {
                        sum += bombField[i, t];
                        count++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < matrixSize; i++)
            {
                for (int t = 0; t < matrixSize; t++)
                {
                    Console.Write(bombField[i, t] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BlowingUpBombs(int matrixSize, int[,] bombField)
        {
            int[] bombPlaces = Regex.Split(Console.ReadLine(), @"\s|,")
                             .Select(int.Parse)
                             .ToArray();

            for (int i = 0; i < bombPlaces.Length; i += 2)
            {
                int row = bombPlaces[i];
                int coll = bombPlaces[i + 1];
                int bombValue = bombField[row, coll];

                if (bombValue <= 0)
                {
                    return;
                }

                bombField[row, coll] = 0;

                bool up = row - 1 >= 0;
                bool down = row + 1 < matrixSize;
                bool left = coll - 1 >= 0;
                bool right = coll + 1 < matrixSize;

                if (up && bombField[row - 1, coll] > 0)
                {
                    bombField[row - 1, coll] -= bombValue;
                }

                if (up && right && bombField[row - 1, coll + 1] > 0)
                {
                    bombField[row - 1, coll + 1] -= bombValue;
                }

                if (right && bombField[row, coll + 1] > 0)
                {
                    bombField[row, coll + 1] -= bombValue;
                }

                if (right && down && bombField[row + 1, coll + 1] > 0)
                {
                    bombField[row + 1, coll + 1] -= bombValue;
                }

                if (down && bombField[row + 1, coll] > 0)
                {
                    bombField[row + 1, coll] -= bombValue;
                }

                if (down && left && bombField[row + 1, coll - 1] > 0)
                {
                    bombField[row + 1, coll - 1] -= bombValue;
                }
                if (left && bombField[row, coll - 1] > 0)
                {
                    bombField[row, coll - 1] -= bombValue;
                }
                if (up && left && bombField[row - 1, coll - 1] > 0)
                {
                    bombField[row - 1, coll - 1] -= bombValue;
                }
            }
        }

        private static void CreatinField(int matrixSize, int[,] bombField)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int t = 0; t < matrixSize; t++)
                {
                    bombField[i, t] = input[t];
                }
            }
        }
    }
}
