using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Enemy
    {
        public void EnemyMoves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        public int[] GetEnemy(char[][] room,Sam sam)
        {
            int[] getEnemy = new int[2];
            for (int j = 0; j < room[sam.Row].Length; j++)
            {
                if (room[sam.Row][j] != '.' && room[sam.Row][j] != 'S')
                {
                    getEnemy[0] = sam.Row;

                    getEnemy[1] = j;
                }
            }
            return getEnemy;
        }

        public void EnemyIntercept(Sam sam,int[] getEnemy,Room room)
        {
            if (sam.Col < getEnemy[1] && room.room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == sam.Row)
            {
                room.room[sam.Row][sam.Col] = 'X';
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                room.PrintingRoom();
            }
            else if (getEnemy[1] < sam.Col && room.room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == sam.Row)
            {
                room.room[sam.Row][sam.Col] = 'X';
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                room.PrintingRoom();
            }
        }
    }
}
