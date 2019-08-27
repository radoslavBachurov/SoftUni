using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int roomWide = int.Parse(Console.ReadLine());
            int roomLong = int.Parse(Console.ReadLine());
            int roomTall = int.Parse(Console.ReadLine());

            int roomCubicMetres = roomWide * roomTall * roomLong;

            int numberBoxes = 0;

            while (numberBoxes < roomCubicMetres)
            {
                string numbernewBoxesOrDone = Console.ReadLine();

                if (numbernewBoxesOrDone == "Done")
                {
                    int spaceLeft = roomCubicMetres - numberBoxes;
                    Console.WriteLine($"{spaceLeft} Cubic meters left.");
                    break;
                }

                int numbernewBoxes = int.Parse(numbernewBoxesOrDone);
                numberBoxes = numbernewBoxes + numberBoxes;
                if (numberBoxes >= roomCubicMetres)
                {
                    int cubicMetresNeeded = numberBoxes - roomCubicMetres;
                    Console.WriteLine($"No more free space! You need {cubicMetresNeeded} Cubic meters more.");
                }
            }
        }

    }

}






