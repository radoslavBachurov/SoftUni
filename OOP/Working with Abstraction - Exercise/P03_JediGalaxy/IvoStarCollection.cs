using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class IvoStarCollection
    {
        private int[,] galaxy;

        public IvoStarCollection(int[,] galaxy)
        {
            this.galaxy = galaxy;
        }

        public long ivoStars { get; private set; }

        public void CollectStars(int[] ivoCoordinates)
        {
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < galaxy.GetLength(1))
            {
                if (ivoRow >= 0 &&
                    ivoRow < galaxy.GetLength(0) &&
                    ivoCol >= 0 &&
                    ivoCol < galaxy.GetLength(1))
                {
                    ivoStars += galaxy[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }
    }
}
