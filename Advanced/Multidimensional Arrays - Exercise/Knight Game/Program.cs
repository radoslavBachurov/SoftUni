using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            Knight[,] board = new Knight[boardSize, boardSize];

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

            int countRemoves = 0;
            bool search = true;
            while (search)
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

                search = false;
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

                int max = int.MinValue;
                int indexRow = -1;
                int indexColl = -1;

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

            Console.WriteLine(countRemoves);
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
