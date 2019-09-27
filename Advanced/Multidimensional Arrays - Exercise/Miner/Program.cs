using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] field = new string[fieldSize, fieldSize];

            string[] moves = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int currentRow = 0;
            int currentColl = 0;
            int coalCollected = 0;
            int coalsOnField = 0;
            CreatingCoalField(fieldSize, field, ref currentRow, ref currentColl, ref coalsOnField);

            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case "left":
                        if (currentColl - 1 >= 0)
                        {
                            currentColl -= 1;
                        }
                        break;
                    case "right":
                        if (currentColl + 1 < fieldSize)
                        {
                            currentColl += 1;
                        }
                        break;
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            currentRow -= 1;
                        }
                        break;
                    case "down":
                        if (currentRow + 1 >= 0)
                        {
                            currentRow += 1;
                        }
                        break;
                }

                if (field[currentRow, currentColl] == "c")
                {
                    field[currentRow, currentColl] = "*";
                    coalCollected++;

                    if (coalCollected == coalsOnField)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentColl})");
                        return;
                    }
                }

                if (field[currentRow, currentColl] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentColl})");
                    return;
                }
            }

            Console.WriteLine($"{coalsOnField - coalCollected} coals left. ({currentRow}, {currentColl})");
        }
        private static void CreatingCoalField(int fieldSize, string[,] field, ref int currentRow, ref int currentColl, ref int coalsOnField)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                string[] input = Regex.Split(Console.ReadLine(), @"\s+").ToArray();

                for (int t = 0; t < fieldSize; t++)
                {
                    field[i, t] = input[t];

                    if (input[t] == "s")
                    {
                        currentRow = i;
                        currentColl = t;
                    }
                    if (input[t] == "c")
                    {
                        coalsOnField++;
                    }
                }
            }
        }
    }
}
