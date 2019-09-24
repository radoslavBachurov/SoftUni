using System;
using System.Text.RegularExpressions;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowColMatrix = int.Parse(Console.ReadLine());

            char[,] newMatrix = new char[rowColMatrix, rowColMatrix];

            for (int i = 0; i < rowColMatrix; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int t = 0; t < rowColMatrix; t++)
                {
                    newMatrix[i, t] = input[t];
                }
            }

            char charToSearch = char.Parse(Console.ReadLine());

            for (int f = 0; f < rowColMatrix; f++)
            {
                for (int t = 0; t < rowColMatrix; t++)
                {
                    if(newMatrix[f,t]==charToSearch)
                    {
                        Console.WriteLine($"({f}, {t})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{charToSearch} does not occur in the matrix");
        }
    }
}
