using System;
using System.Linq;

namespace _03_Arrays_exercise
{
    class Program
    {
        static void Main(string[] args)
        {

            //PROBLEM 10 - LADY BUGS

            int fieldSize = int.Parse(Console.ReadLine());
            int[] fieldSizeArray = new int[fieldSize];
            string input = string.Empty;
            long[] initialPositionsOfAllBugs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            for (int k = 0; k < initialPositionsOfAllBugs.Length; k++)
            {
                if (initialPositionsOfAllBugs[k] < fieldSizeArray.Length)
                {
                    fieldSizeArray[initialPositionsOfAllBugs[k]] = 1;
                }

            }

            while ((input = Console.ReadLine()) != "end")
            {
                string[] move = input.Split().ToArray();
                int bugPosition = int.Parse(move[0]);
                int desiredMoves = int.Parse(move[2]);
                string direction = move[1];
                if (bugPosition < 0)
                    continue;

                if (direction == "left" && bugPosition >= 0 && bugPosition < fieldSize)
                {

                    bool seatTaken = fieldSizeArray[bugPosition] == 1;
                    if (desiredMoves != 0 && seatTaken)
                    {

                        fieldSizeArray[bugPosition] = 0;
                        while (true)
                        {
                            bugPosition -= desiredMoves;

                            if (bugPosition < 0 || bugPosition >= fieldSize)
                                break;

                            seatTaken = fieldSizeArray[bugPosition] == 1;

                            if (!seatTaken)
                            {
                                fieldSizeArray[bugPosition] = 1;
                                break;
                            }
                        }

                    }


                }
                else if (direction == "right" && bugPosition >= 0 && bugPosition < fieldSize)
                {


                    bool seatTaken = fieldSizeArray[bugPosition] == 1;
                    if (desiredMoves != 0 && seatTaken)
                    {

                        fieldSizeArray[bugPosition] = 0;
                        while (true)
                        {
                            bugPosition += desiredMoves;

                            if (bugPosition < 0 || bugPosition >= fieldSize)
                                break;

                            seatTaken = fieldSizeArray[bugPosition] == 1;

                            if (!seatTaken)
                            {
                                fieldSizeArray[bugPosition] = 1;
                                break;
                            }
                        }

                    }



                }

            }
            foreach (var num in fieldSizeArray)
            {
                Console.Write(num + " ");
            }


        }
    }
}