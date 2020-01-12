using System;

namespace NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintMatrix(number);
        }

        private static void PrintMatrix(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int t = 0; t < number; t++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
