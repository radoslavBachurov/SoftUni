using System;
using System.Linq;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] galaxy = new char[size, size];
            int peterRow = 0;
            int peterCol = 0;
            int energy = 0;

            CreatingGalaxy(size, galaxy, ref peterRow, ref peterCol);

            while (InGalaxyBorders(galaxy, peterCol, peterRow) && energy < 50)
            {
                MovingInTheGalaxy(size, galaxy, ref peterRow, ref peterCol, ref energy);
            }

            Printing(size, galaxy, peterRow, peterCol, energy);

        }

        private static void MovingInTheGalaxy(int size, char[,] galaxy, ref int peterRow, ref int peterCol, ref int energy)
        {
            string direction = Console.ReadLine();
            galaxy[peterRow, peterCol] = '-';

            switch (direction)
            {
                case "up":
                    peterRow -= 1;
                    break;
                case "down":
                    peterRow += 1;
                    break;
                case "left":
                    peterCol -= 1;
                    break;
                case "right":
                    peterCol += 1;
                    break;
            }

            if (InGalaxyBorders(galaxy, peterCol, peterRow))
            {
                if (char.IsDigit(galaxy[peterRow, peterCol]))
                {
                    energy += int.Parse(galaxy[peterRow, peterCol].ToString());
                }
                else if (galaxy[peterRow, peterCol] == 'O')
                {
                    SuckedInBlackHole(size, galaxy, ref peterRow, ref peterCol);
                }
            }
        }

        private static void CreatingGalaxy(int size, char[,] galaxy, ref int peterRow, ref int peterCol)
        {
            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
                for (int t = 0; t < size; t++)
                {
                    galaxy[i, t] = input[t];
                    if (input[t] == 'S')
                    {
                        peterRow = i;
                        peterCol = t;
                    }
                }
            }
        }

        private static void Printing(int size, char[,] galaxy, int peterRow, int peterCol, int energy)
        {
            if (energy >= 50)
            {
                galaxy[peterRow, peterCol] = 'S';
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {energy}");
            }
            else
            {
                Console.WriteLine($"Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {energy}");
            }

            for (int i = 0; i < size; i++)
            {
                for (int t = 0; t < size; t++)
                {
                    Console.Write(galaxy[i, t]);
                }
                Console.WriteLine();
            }
        }

        private static void SuckedInBlackHole(int size, char[,] galaxy, ref int peterRow, ref int peterCol)
        {
            for (int i = 0; i < size; i++)
            {
                for (int t = 0; t < size; t++)
                {
                    if (galaxy[i, t] == 'O' && (i != peterRow || t != peterCol))
                    {
                        galaxy[peterRow, peterCol] = '-';
                        peterRow = i;
                        peterCol = t;
                    }
                }
            }
        }

        private static bool InGalaxyBorders(char[,] galaxy, int peterCol, int peterRow)
        {
            if (peterRow >= 0 &&
                peterRow < galaxy.GetLength(0) &&
                peterCol >= 0 &&
                peterCol < galaxy.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
