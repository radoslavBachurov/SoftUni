using System;
using System.Collections.Generic;

namespace RhombusOfStars
{
    class Startup
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            CreatingRhombus(number);

        }

        private static void CreatingRhombus(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                PrintRow(number, row);
            }

            for (int row = number - 1; row >= 1; row--)
            {
                PrintRow(number, row);
            }
        }

        private static void PrintRow(int number, int row)
        {
            for (int ws = 0; ws < number - row; ws++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < row; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
