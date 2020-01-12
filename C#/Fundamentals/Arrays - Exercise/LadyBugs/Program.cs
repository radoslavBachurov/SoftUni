using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            int[] inputBugIndexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] bugIndexes = new int[sizeField];

            for (int i = 0; i < inputBugIndexes.Length; i++)
            {
                if (inputBugIndexes[i] >= 0 && inputBugIndexes[i] < sizeField)
                    bugIndexes[inputBugIndexes[i]] = 1;
            }

            while (true)
            {
                string moves = Console.ReadLine();

                if (moves == "end")
                    break;

                string[] command = moves.Split(" ").ToArray();
                int currentLocation = int.Parse(command[0]);
                int range = int.Parse(command[2]);
               
                if (currentLocation < 0)
                    continue;

                if (moves.Contains("left") && currentLocation >= 0 && currentLocation < sizeField)
                {
                    bool seatTaken = bugIndexes[currentLocation] == 1;
                    if (range != 0 && seatTaken)
                    {
                        bugIndexes[currentLocation] = 0;
                        while (true)
                        {
                            currentLocation -= range;

                            if (currentLocation < 0 || currentLocation >= sizeField)
                                break;

                            seatTaken = bugIndexes[currentLocation] == 1;

                            if (!seatTaken)
                            {
                                bugIndexes[currentLocation] = 1;
                                break;
                            }
                        }
                    }


                }
                else if (moves.Contains("right") && currentLocation >= 0 && currentLocation < sizeField)
                {
                    bool seatTaken = bugIndexes[currentLocation] == 1;
                    if (range != 0 && seatTaken)
                    {
                        bugIndexes[currentLocation] = 0;
                        while (true)
                        {
                            currentLocation += range;

                            if (currentLocation < 0 || currentLocation >= sizeField)
                                break;

                            seatTaken = bugIndexes[currentLocation] == 1;

                            if (!seatTaken)
                            {
                                bugIndexes[currentLocation] = 1;
                                break;
                            }

                        }
                    }

                }

            }
            Console.WriteLine(string.Join(" ", bugIndexes));

        }






    }
}

