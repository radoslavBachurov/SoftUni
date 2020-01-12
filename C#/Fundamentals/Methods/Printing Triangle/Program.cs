using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
            PrintReverseTriangle(number);
        }

        private static void PrintReverseTriangle(int number)
        {
            for (int rows = number - 1; rows >= 0; rows--)
            {
                PrintRows(rows);
            }
        }

        private static void PrintTriangle(int number)
        {
            for (int rows = 1; rows <= number; rows++)
            {
                PrintRows(rows);
            }
        }

        private static void PrintRows(int rows)
        {
            for (int collums = 1; collums <= rows; collums++)
            {
                Console.Write($"{collums} ");
            }
            Console.WriteLine();
        }
    }
}
