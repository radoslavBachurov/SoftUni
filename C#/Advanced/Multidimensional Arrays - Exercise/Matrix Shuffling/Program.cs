using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColls = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string[,] stringMatrix = new string[rowsColls[0], rowsColls[1]];

            for (int i = 0; i < rowsColls[0]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < rowsColls[1]; j++)
                {
                    stringMatrix[i, j] = input[j];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()?.ToLower()) != "end")
            {
                string[] commandArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int row1 = 0;
                int col1 = 0;
                int row2 = 0;
                int col2 = 0;
                bool verification = commandArr.Length == 5 &&
                    commandArr[0] == "swap" &&
                    int.TryParse(commandArr[1], out row1) &&
                    int.TryParse(commandArr[2], out col1) &&
                    int.TryParse(commandArr[3], out row2) &&
                    int.TryParse(commandArr[4], out col2) &&
                    row1 >= 0 && row1 < rowsColls[0] &&
                    row2 >= 0 && row2 < rowsColls[0] &&
                    col1 >= 0 && col1 < rowsColls[1] &&
                    col2 >= 0 && col2 < rowsColls[1];

                if(verification)
                {
                    string firstValue = stringMatrix[row1, col1];
                    stringMatrix[row1, col1] = stringMatrix[row2, col2];
                    stringMatrix[row2, col2] = firstValue;

                    for (int i = 0; i < rowsColls[0]; i++)
                    {
                        for (int t = 0; t < rowsColls[1]; t++)
                        {
                            Console.Write($"{stringMatrix[i,t]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                    

            }

        }
    }
}
