using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Startup
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] galaxy = CreatingGalaxy(dimestions);
            IvoStarCollection newCollection = new IvoStarCollection(galaxy);

            string input = string.Empty;
            
            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                EvilMoves(galaxy, evilCoordinates);

                newCollection.CollectStars(ivoCoordinates);
            }

            Console.WriteLine(newCollection.ivoStars);

        }

        private static void EvilMoves(int[,] galaxy, int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 &&
                    evilRow < galaxy.GetLength(0) &&
                    evilCol >= 0 &&
                    evilCol < galaxy.GetLength(1))
                {
                    galaxy[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static int[,] CreatingGalaxy(int[] dimestions)
        {
            int galaxyRow = dimestions[0];
            int galaxyCol = dimestions[1];

            int[,] galaxy = new int[galaxyRow, galaxyCol];

            int value = 0;
            for (int i = 0; i < galaxyRow; i++)
            {
                for (int j = 0; j < galaxyCol; j++)
                {
                    galaxy[i, j] = value++;
                }
            }

            return galaxy;
        }
    }
}
