using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Sam
    {
        public Sam(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        this.Row = row;
                        this.Col = col;
                    }
                }
            }
        }
        public int Row { get; private set; }
        public int Col { get; private set; }

        public void SamIntercept(int[] getEnemy,Room room,Sam sam)
        {
            if (room.room[getEnemy[0]][getEnemy[1]] == 'N' && sam.Row == getEnemy[0])
            {
                room.room[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                room.PrintingRoom();
                return;
            }
        }

        public void SamMoves(char[][] room,char[] moves,Sam sam,int i)
        {
            room[sam.Row][sam.Col] = '.';
            switch (moves[i])
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
                default:
                    break;
            }
            room[sam.Row][sam.Col] = 'S';
        }
    }
}
