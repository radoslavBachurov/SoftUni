using System;
using System.Linq;

namespace Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int numberRows = int.Parse(Console.ReadLine());

            char[] rowField = Console.ReadLine().ToCharArray();
            char[,] field = new char[numberRows, rowField.Length];
            CreatingField(numberRows, rowField, field);

            int parisRow = 0;
            int parisColl = 0;

            for (int i = 0; i < numberRows; i++)
            {
                for (int t = 0; t < rowField.Length; t++)
                {
                    if (field[i, t] == 'P')
                    {
                        parisRow = i;
                        parisColl = t;
                    }
                }
            }

            while (energy > 0)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string direction = input[0];
                int row = int.Parse(input[1]);
                int coll = int.Parse(input[2]);

                field[row, coll] = 'S';
                field[parisRow, parisColl] = '-';
                energy--;

                ChangingDirection(numberRows, rowField, ref parisRow, ref parisColl, direction);

                if (field[parisRow, parisColl] == 'S')
                {
                    energy -= 2;
                }
                else if (field[parisRow, parisColl] == 'H')
                {
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    field[parisRow, parisColl] = '-';
                    break;
                }

                if (energy <= 0)
                {
                    Console.WriteLine($"Paris died at {parisRow};{parisColl}.");
                    field[parisRow, parisColl] = 'X';
                    break;
                }
            }

            PrintingField(numberRows, rowField, field);

        }

        private static void PrintingField(int numberRows, char[] rowField, char[,] field)
        {
            for (int row = 0; row < numberRows; row++)
            {
                for (int col = 0; col < rowField.Length; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ChangingDirection(int numberRows, char[] rowField, ref int parisRow, ref int parisColl, string direction)
        {
            switch (direction)
            {
                case "up":
                    if (parisRow - 1 >= 0)
                    {
                        parisRow -= 1;
                    }
                    break;
                case "down":
                    if (parisRow + 1 < numberRows)
                    {
                        parisRow += 1;
                    }
                    break;
                case "left":
                    if (parisColl - 1 >= 0)
                    {
                        parisColl -= 1;
                    }
                    break;
                case "right":
                    if (parisColl + 1 < rowField.Length)
                    {
                        parisColl += 1;
                    }
                    break;
            }
        }

        private static void CreatingField(int numberRows, char[] rowField, char[,] field)
        {
            for (int i = 0; i < numberRows; i++)
            {
                for (int t = 0; t < rowField.Length; t++)
                {
                    field[i, t] = rowField[t];
                }
                if (i + 1 < numberRows)
                {
                    rowField = Console.ReadLine().ToCharArray();
                }
            }
        }
    }
}
