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
            CreatingField(rowsSize, collSize, field, ref playerRow, ref playerCol);

            char[] moves = Console.ReadLine().ToCharArray();
            field[playerRow, playerCol] = '.';

            for (int i = 0; i < moves.Length; i++)
            {
                char currentMove = moves[i];

                List<Bunny> bunnyCoordinates = new List<Bunny>();

                TrackingBunnyCoordinates(rowsSize, collSize, field, bunnyCoordinates);
                BunnySpreadTracker(rowsSize, collSize, field, bunnyCoordinates);

                int previousRow = playerRow;
                int previousCol = playerCol;

                MakingMoves(ref playerRow, ref playerCol, currentMove);

                bool win = playerRow < 0 || playerRow >= rowsSize || playerCol < 0 || playerCol >= collSize;

                if (win)
                {
                    WinPrinting(rowsSize, collSize, field, previousRow, previousCol);
                    return;
                }
                else if (field[playerRow, playerCol] == 'B')
                {
                    DeadPrinting(rowsSize, collSize, field, playerRow, playerCol);
                    return;
                }
            }

        }

        private static void DeadPrinting(int rowsSize, int collSize, char[,] field, int playerRow, int playerCol)
        {
            for (int r = 0; r < rowsSize; r++)
            {
                for (int c = 0; c < collSize; c++)
                {
                    Console.Write(field[r, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"dead: {playerRow} {playerCol}");
            return;
        }

        private static void WinPrinting(int rowsSize, int collSize, char[,] field, int previousRow, int previousCol)
        {
            for (int r = 0; r < rowsSize; r++)
            {
                for (int c = 0; c < collSize; c++)
                {
                    Console.Write(field[r, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"won: {previousRow} {previousCol}");
            return;
        }

        private static void MakingMoves(ref int playerRow, ref int playerCol, char currentMove)
        {
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
        }

        private static void BunnySpreadTracker(int rowsSize, int collSize, char[,] field, List<Bunny> bunnyCoordinates)
        {
            foreach (var item in bunnyCoordinates)
            {
                int row = item.Row;
                int coll = item.Coll;

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
        }

        private static void TrackingBunnyCoordinates(int rowsSize, int collSize, char[,] field, List<Bunny> bunnyCoordinates)
        {
            for (int j = 0; j < rowsSize; j++)
            {
                for (int t = 0; t < collSize; t++)
                {
                    if (field[j, t] == 'B')
                    {
                        Bunny newBunny = new Bunny(j, t);
                        bunnyCoordinates.Add(newBunny);
                    }
                }
            }
        }

        private static void CreatingField(int rowsSize, int collSize, char[,] field, ref int playerRow, ref int playerCol)
        {
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
        }
    }
    class Bunny
    {
        public Bunny(int row,int coll)
        {
            Row = row;
            Coll = coll;
        }
        public int Row { get; set; }
        public int Coll { get; set; }
    }
}
