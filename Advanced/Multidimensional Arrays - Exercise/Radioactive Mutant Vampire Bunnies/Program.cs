using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeInput = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int rowsSize = sizeInput[0];
            int collSize = sizeInput[1];
            char[,] field = new char[rowsSize, collSize];

            int playerRow = 0;
            int playerCol = 0;

            for (int i = 0; i < rowsSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int t = 0; t < collSize; t++)
                {
                    field[i, t] = input[t];

                    if (input[t] == 'P')
                    {
                        playerRow = i;
                        playerCol = t;
                    }
                }
            }

            char[] moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                char currentMove = moves[i];

                Dictionary<int, int> bunnyCoordinates = new Dictionary<int, int>();

                for (int j = 0; j < playerRow; j++)
                {
                    for (int t = 0; t < playerCol; t++)
                    {
                        if (field[j, t] == 'B')
                        {
                            bunnyCoordinates[j] = t;
                        }
                    }
                }

                foreach (var item in bunnyCoordinates)
                {
                    int row = item.Key;
                    int coll = item.Value;

                    if (row - 1 >= 0)
                    {
                        field[row - 1, coll] = 'B';
                    }
                    if (row + 1 < rowsSize)
                    {
                        field[row + 1, coll] = 'B';
                    }
                    if (coll - 1 >= 0)
                    {
                        field[row, coll - 1] = 'B';
                    }
                    if (coll + 1 < collSize)
                    {
                        field[row, coll + 1] = 'B';
                    }
                }

                int previousRow = playerRow;
                int previousCol = playerCol;

                switch (currentMove)
                {
                    case 'U':
                        playerRow -= 1;
                        break;
                    case 'D':
                        playerRow += 1;
                        break;
                    case 'L':
                        playerCol -= 1;
                        break;
                    case 'R':
                        playerCol += 1;
                        break;
                }

                bool win = playerRow < 0 || playerRow >= rowsSize || playerCol < 0 || playerCol >= collSize;

                if (win)
                {
                    Console.WriteLine($"won: {previousRow} {previousCol}");
                    return;
                }
                else if (field[playerRow, playerCol] == 'B')
                {
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }

        }
    }
}
