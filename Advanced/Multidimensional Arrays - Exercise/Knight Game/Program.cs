using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_Game
{
    class Program
    {
        static char[,] chessBoard;
        static Dictionary<int, Parameter> moveParametres;
        static int countRemoves;

        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            chessBoard = new char[boardSize, boardSize];

            CreatingChessBoard();
            moveParametres = new Dictionary<int, Parameter>();
            CreatingParametres();

            FindingMostAgressiveHorse();
            Console.WriteLine(countRemoves);
        }

        private static void CreatingParametres()
        {
            moveParametres.Add(1, new Parameter(-2, 1));
            moveParametres.Add(2, new Parameter(-2, -1));
            moveParametres.Add(3, new Parameter(2, 1));
            moveParametres.Add(4, new Parameter(2, -1));
            moveParametres.Add(5, new Parameter(1, 2));
            moveParametres.Add(6, new Parameter(-1, 2));
            moveParametres.Add(7, new Parameter(1, -2));
            moveParametres.Add(8, new Parameter(-1, -2));
        }

        private static void FindingMostAgressiveHorse()
        {
            countRemoves = 0;
            int mostAgrresiveHorse = 1;

            while (mostAgrresiveHorse != 0)
            {
                int agressiveHorseRow = 0;
                int agressiveHorseBoll = 0;
                mostAgrresiveHorse = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int coll = 0; coll < chessBoard.GetLength(1); coll++)
                    {
                        int currentHorseAtackPoints = 0;

                        foreach (var parametres in moveParametres)
                        {
                            if (chessBoard[row, coll] == 'K' &&
                                Validation(row + parametres.Value.Row, coll + parametres.Value.Coll))
                            {
                                currentHorseAtackPoints++;
                            }
                        }

                        if (currentHorseAtackPoints > mostAgrresiveHorse)
                        {
                            mostAgrresiveHorse = currentHorseAtackPoints;
                            agressiveHorseRow = row;
                            agressiveHorseBoll = coll;
                        }
                    }
                }

                if (mostAgrresiveHorse != 0)
                {
                    chessBoard[agressiveHorseRow, agressiveHorseBoll] = '0';
                    countRemoves++;
                }
            }
        }

        private static bool Validation(int row, int coll)
        {
            return row >= 0 && row < chessBoard.GetLength(0) &&
                coll >= 0 && coll < chessBoard.GetLength(1) &&
                chessBoard[row, coll] == 'K';
        }

        private static void CreatingChessBoard()
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray()
                    .Where(c => c != ' ')
                    .ToArray();

                for (int coll = 0; coll < chessBoard.GetLength(1); coll++)
                {
                    chessBoard[row, coll] = input[coll];
                }
            }
        }
    }
    class Parameter
    {
        public Parameter(int row, int coll)
        {
            Row = row;
            Coll = coll;
        }
        public int Row { get; set; }
        public int Coll { get; set; }
    }
}

