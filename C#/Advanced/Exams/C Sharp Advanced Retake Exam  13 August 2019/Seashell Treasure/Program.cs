using System;
using System.Collections.Generic;
using System.Linq;

namespace Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int beachRows = int.Parse(Console.ReadLine());
            char[][] beach = new char[beachRows][];

            CreatingBeach(beachRows, beach);
            List<char> collectedShels = new List<char>();
            List<char> stolenShells = new List<char>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sunset")
            {
                string[] inputArr = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArr[0] == "Collect")
                {
                    CollectingSeaShells(beach, collectedShels, inputArr);
                }
                else if (inputArr[0] == "Steal")
                {
                    StealingSeaShells(beach, stolenShells, inputArr);
                }
            }

            Printing(beachRows, beach, collectedShels, stolenShells);
        }

        private static void Printing(int beachRows, char[][] beach, List<char> collectedShels, List<char> stolenShells)
        {
            for (int i = 0; i < beachRows; i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }

            Console.Write($"Collected seashells: {collectedShels.Count}");
            if (collectedShels.Count > 0)
            {
                Console.WriteLine($" -> {string.Join(", ", collectedShels)}");
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine($"Stolen seashells: {stolenShells.Count}");
        }

        private static void StealingSeaShells(char[][] beach, List<char> stolenShells, string[] inputArr)
        {
            int row = int.Parse(inputArr[1]);
            int col = int.Parse(inputArr[2]);
            string direction = inputArr[3];

            for (int i = 0; i < 4; i++)
            {
                if (i > 0)
                {
                    switch (direction)
                    {
                        case "left":
                            col -= 1;
                            break;
                        case "right":
                            col += 1;
                            break;
                        case "up":
                            row -= 1;
                            break;
                        case "down":
                            row += 1;
                            break;
                    }
                }

                if (IsInTheBeach(row, col, beach))
                {
                    if (beach[row][col] != '-')
                    {
                        stolenShells.Add(beach[row][col]);
                    }
                    beach[row][col] = '-';
                }
                else
                {
                    return;
                }
            }
        }

        private static void CollectingSeaShells(char[][] beach, List<char> collectedShels, string[] inputArr)
        {
            int row = int.Parse(inputArr[1]);
            int col = int.Parse(inputArr[2]);

            if (IsInTheBeach(row, col, beach))
            {
                if (beach[row][col] != '-')
                {
                    collectedShels.Add(beach[row][col]);
                }
                beach[row][col] = '-';
            }
        }

        private static bool IsInTheBeach(int row, int cow, char[][] beach)
        {
            if (row >= 0 && row < beach.Length && cow >= 0 && cow < beach[row].Length)
            {
                return true;
            }

            return false;
        }

        private static void CreatingBeach(int beachRows, char[][] beach)
        {
            for (int i = 0; i < beachRows; i++)
            {
                beach[i] = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
            }
        }
    }
}
