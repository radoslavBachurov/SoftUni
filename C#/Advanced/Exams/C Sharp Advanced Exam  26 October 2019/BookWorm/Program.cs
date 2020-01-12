using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> initialString = new Stack<char>(Console.ReadLine().ToCharArray().ToArray());
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < size; i++)
            {
                char[] inputArr = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();

                for (int t = 0; t < size; t++)
                {
                    field[i, t] = inputArr[t];
                    if (field[i, t] == 'P')
                    {
                        playerRow = i;
                        playerCol = t;
                    }
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                field[playerRow, playerCol] = '-';

                switch (input)
                {
                    case "up":
                        playerRow -= 1;
                        if (CheckForFieldBorders(playerRow, playerCol, size))
                        {
                            if (field[playerRow, playerCol] != '-')
                            {
                                initialString.Push(field[playerRow, playerCol]);
                            }
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.Pop();
                            }
                            playerRow += 1;
                        }
                        break;
                    case "down":
                        playerRow += 1;
                        if (CheckForFieldBorders(playerRow, playerCol, size))
                        {
                            if (field[playerRow, playerCol] != '-')
                            {
                                initialString.Push(field[playerRow, playerCol]);
                            }
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.Pop();
                            }
                            playerRow -= 1;
                        }
                        break;
                    case "left":
                        playerCol -= 1;
                        if (CheckForFieldBorders(playerRow, playerCol, size))
                        {
                            if (field[playerRow, playerCol] != '-')
                            {
                                initialString.Push(field[playerRow, playerCol]);
                            }
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.Pop();
                            }
                            playerCol += 1;
                        }
                        break;
                        
                    case "right":
                        playerCol += 1;
                        if (CheckForFieldBorders(playerRow, playerCol, size))
                        {
                            if (field[playerRow, playerCol] != '-')
                            {
                                initialString.Push(field[playerRow, playerCol]);
                            }
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.Pop();
                            }
                            playerCol -= 1;
                        }
                        break;
                }
               
            }

            field[playerRow, playerCol] = 'P';
            string finalState = string.Empty;
            initialString = new Stack<char>(initialString);
            Console.WriteLine(string.Join("",initialString));


           for (int i = 0; i < size; i++)
            {
                for (int t = 0; t < size; t++)
                {
                    Console.Write(field[i, t]);
                }
                Console.WriteLine();
            }

        }

        private static bool CheckForFieldBorders(int playerRow, int playerCol, int size)
        {
            if (playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size)
            {
                return true;
            }
            return false;
        }
    }
}
