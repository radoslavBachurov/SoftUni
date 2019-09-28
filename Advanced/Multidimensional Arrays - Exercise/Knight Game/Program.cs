using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            Knight[,] board = new Knight[boardSize, boardSize];
            CreatingBoards(boardSize, board);

            int countRemoves = 0;
            bool search = true;
            while (search)
            {
                RefreshingThreatInformation(boardSize, board);

                search = false;
                search = FindingMostThreatedHorse(boardSize, board, search);

                int max = int.MinValue;
                int indexRow = -1;
                int indexColl = -1;
                RemovesMostThreatedHorse(boardSize, board, ref countRemoves, ref max, ref indexRow, ref indexColl);
            }

            Console.WriteLine(countRemoves);
        }

        private static void RemovesMostThreatedHorse(int boardSize, Knight[,] board, ref int countRemoves, ref int max, ref int indexRow, ref int indexColl)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int t = 0; t < boardSize; t++)
                {
                    if (board[i, t].canTakeHits > max)
                    {
                        max = board[i, t].canTakeHits;
                        indexRow = i;
                        indexColl = t;
                    }
                }
            }

            if (max != -1 && max != 0)
            {
                board[indexRow, indexColl].canTakeHits = -1;
                countRemoves++;
            }
        }

        private static bool FindingMostThreatedHorse(int boardSize, Knight[,] board, bool search)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int t = 0; t < boardSize; t++)
                {
                    if (i - 2 >= 0 && t - 1 >= 0 && board[i, t].canTakeHits != -1)
                    {
                        if (board[i - 2, t - 1].canTakeHits != -1)
                        {
                            board[i - 2, t - 1].canTakeHits++;
                            search = true;
                        }
                    }
                    if (i - 2 >= 0 && t + 1 < boardSize && board[i, t].canTakeHits != -1)
                    {
                        if (board[i - 2, t + 1].canTakeHits != -1)
                        {
                            board[i - 2, t + 1].canTakeHits++;
                            search = true;
                        }
                    }
                    if (i + 2 < boardSize && t - 1 >= 0 && board[i, t].canTakeHits != -1)
                    {
                        if (board[i + 2, t - 1].canTakeHits != -1)
                        {
                            board[i + 2, t - 1].canTakeHits++;
                            search = true;
                        }
                    }
                    if (i + 2 < boardSize && t + 1 < boardSize && board[i, t].canTakeHits != -1)
                    {
                        if (board[i + 2, t + 1].canTakeHits != -1)
                        {
                            board[i + 2, t + 1].canTakeHits++;
                            search = true;
                        }
                    }
                    if (t - 2 >= 0 && i - 1 >= 0 && board[i, t].canTakeHits != -1)
                    {
                        if (board[i - 1, t - 2].canTakeHits != -1)
                        {
                            board[i - 1, t - 2].canTakeHits++;
                            search = true;
                        }
                    }
                    if (t - 2 >= 0 && i + 1 < boardSize && board[i, t].canTakeHits != -1)
                    {
                        if (board[i + 1, t - 2].canTakeHits != -1)
                        {
                            board[i + 1, t - 2].canTakeHits++;
                            search = true;
                        }
                    }
                    if (t + 2 < boardSize && i - 1 >= 0 && board[i, t].canTakeHits != -1)
                    {
                        if (board[i - 1, t + 2].canTakeHits != -1)
                        {
                            board[i - 1, t + 2].canTakeHits++;
                            search = true;
                        }
                    }
                    if (t + 2 < boardSize && i + 1 < boardSize && board[i, t].canTakeHits != -1)
                    {
                        if (board[i + 1, t + 2].canTakeHits != -1)
                        {
                            board[i + 1, t + 2].canTakeHits++;
                            search = true;
                        }
                    }
                }
            }

            return search;
        }

        private static void RefreshingThreatInformation(int boardSize, Knight[,] board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int t = 0; t < boardSize; t++)
                {
                    if (board[i, t].canTakeHits != -1)
                    {
                        board[i, t].canTakeHits = 0;
                    }
                }
            }
        }

        private static void CreatingBoards(int boardSize, Knight[,] board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int t = 0; t < boardSize; t++)
                {
                    if (input[t] == '0')
                    {
                        board[i, t] = new Knight(-1);
                    }
                    else
                    {
                        board[i, t] = new Knight(0);
                    }
                }
            }
        }
    }
    class Knight
    {
        public Knight(int input)
        {
            canTakeHits = input;
        }
        public int canTakeHits { get; set; }
    }
}
