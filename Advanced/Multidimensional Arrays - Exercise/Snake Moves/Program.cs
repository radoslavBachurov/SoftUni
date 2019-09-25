using System;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] isle = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] snake = Console.ReadLine().ToCharArray();
            char[,] snakeMatrix = new char[isle[0], isle[1]];

            int rows = 0;
            int colls = 0;
            while (rows != isle[0])
            {
                if (rows % 2 == 0)
                {
                    colls = 0;
                }
                else
                {
                    colls = isle[1] - 1;
                }

                while (colls != isle[1] && colls != -1)
                {
                    snakeMatrix[rows, colls] = snake[0];
                    char firstChar = snake[0];
                    for (int i = 0; i < snake.Length - 1; i++)
                    {
                        snake[i] = snake[i + 1];
                    }
                    snake[snake.Length - 1] = firstChar;

                    if (rows % 2 == 0)
                    {
                        colls++;
                    }
                    else
                    {
                        colls--;
                    }
                }
                rows++;
            }

            for (int i = 0; i < isle[0]; i++)
            {
                for (int t = 0; t < isle[1]; t++)
                {
                    Console.Write(snakeMatrix[i, t]);
                }
                Console.WriteLine();
            }
        }
    }
}
