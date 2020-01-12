using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());
            int[][] jaggetArr = new int[numberRows][];

            for (int i = 0; i < numberRows; i++)
            {
                jaggetArr[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()?.ToLower()) != "end")
            {
                string[] commandArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArr[0].ToLower() == "add")
                {
                    int row = int.Parse(commandArr[1]);
                    int collum = int.Parse(commandArr[2]);
                    int value = int.Parse(commandArr[3]);

                    if (jaggetArr.Length > row && 
                        row >= 0 && 
                        jaggetArr[row].Length > collum && 
                        collum >= 0)
                    {
                        jaggetArr[row][collum] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    int row = int.Parse(commandArr[1]);
                    int collum = int.Parse(commandArr[2]);
                    int value = int.Parse(commandArr[3]);

                    if (jaggetArr.Length > row &&
                        row >= 0 &&
                        jaggetArr[row].Length > collum &&
                        collum >= 0)
                    {
                        jaggetArr[row][collum] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            foreach (var item in jaggetArr)
            {
                Console.WriteLine(string.Join(" ",item));
            }

        }
    }
}
