using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWide = int.Parse(Console.ReadLine());
            int cakeLong = int.Parse(Console.ReadLine());

            int areaCake = cakeLong * cakeWide;
            int piecesTaken = 0;

            while (areaCake>=piecesTaken)
            {
                string piecesTakenOrStop = Console.ReadLine();
                if (piecesTakenOrStop == "STOP")
                {
                    int piecesLeft = areaCake - piecesTaken;
                    Console.WriteLine($"{piecesLeft} pieces are left.");
                    break;
                }
                piecesTaken += int.Parse(piecesTakenOrStop);
            }
            if (areaCake < piecesTaken)
            {
                int piecesneeded = piecesTaken - areaCake;
                Console.WriteLine($"No more cake left! You need {piecesneeded} pieces more.");
            }
            


        }
    }
}
