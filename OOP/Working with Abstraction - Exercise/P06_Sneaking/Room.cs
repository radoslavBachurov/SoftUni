using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Room
    {
        public Room(int rows)
        {
            this.room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        public char[][] room { get; private set; }

        public void PrintingRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
