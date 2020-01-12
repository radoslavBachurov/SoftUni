using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    class Engine
    {
        private Enemy newEnemy;
        private Room newRoom;
        private Sam sam;

        public Engine(int rows)
        {
            this.newEnemy = new Enemy();
            this.newRoom = new Room(rows);
            this.sam = new Sam(this.newRoom.room);
        }

        public void Run()
        {
            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                newEnemy.EnemyMoves(newRoom.room);

                int[] getEnemy = newEnemy.GetEnemy(newRoom.room, sam);

                newEnemy.EnemyIntercept(sam, getEnemy, newRoom);

                if (newRoom.room[sam.Row][sam.Col] == 'X')
                {
                    return;
                }

                sam.SamMoves(newRoom.room, moves, sam, i);

                getEnemy = newEnemy.GetEnemy(newRoom.room, sam);

                sam.SamIntercept(getEnemy, newRoom, sam);

                if (newRoom.room[getEnemy[0]][getEnemy[1]] == 'X')
                {
                    return;
                }
            }
        }
    }
}
