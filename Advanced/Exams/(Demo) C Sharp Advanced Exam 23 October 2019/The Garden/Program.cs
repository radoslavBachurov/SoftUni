using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];

            Dictionary<string, int> harvestedCrops = new Dictionary<string, int>();
            harvestedCrops.Add("Carrots", 0);
            harvestedCrops.Add("Potatoes", 0);
            harvestedCrops.Add("Lettuce", 0);
            harvestedCrops.Add("Harmed vegetables", 0);

            for (int i = 0; i < rows; i++)
            {
                field[i] = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputArr[0];
                int row = int.Parse(inputArr[1]);
                int col = int.Parse(inputArr[2]);

                if (InFieldBorders(row, col, field))
                {
                    string marker = string.Empty;
                    if (command == "Harvest")
                    {
                        Harvest(field, harvestedCrops, row, col, marker);
                    }
                    else if (command == "Mole")
                    {
                        Mole(field, harvestedCrops, inputArr, row, col);
                    }
                }
            }

            Printing(field, harvestedCrops);

        }

        private static void Mole(char[][] field, Dictionary<string, int> harvestedCrops, string[] inputArr, int row, int col)
        {
            string marker = "Harmed vegetables";
            string direction = inputArr[3].ToLower();
            while (InFieldBorders(row, col, field))
            {
                if (field[row][col] != ' ')
                {
                    harvestedCrops[marker]++;
                    field[row][col] = ' ';
                }

                switch (direction)
                {
                    case "up":
                        row -= 2;
                        break;
                    case "down":
                        row += 2;
                        break;
                    case "left":
                        col -= 2;
                        break;
                    case "right":
                        col += 2;
                        break;
                }
            }
        }

        private static void Harvest(char[][] field, Dictionary<string, int> harvestedCrops, int row, int col, string marker)
        {
            if (field[row][col] == 'L' || field[row][col] == 'P' || field[row][col] == 'C')
            {
                if (field[row][col] == 'L')
                {
                    marker = "Lettuce";
                }
                if (field[row][col] == 'C')
                {
                    marker = "Carrots";
                }
                if (field[row][col] == 'P')
                {
                    marker = "Potatoes";
                }
                harvestedCrops[marker]++;
                field[row][col] = ' ';
            }
        }

        private static void Printing(char[][] field, Dictionary<string, int> harvestedCrops)
        {
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(string.Join(" ", field[i]));
            }

            foreach (var item in harvestedCrops)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static bool InFieldBorders(int row, int col, char[][] field)
        {
            if (row < 0 || row >= field.Length || col < 0 || col >= field[row].Length)
            {
                return false;
            }
            return true;
        }
    }
}
