using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double countNumbers = int.Parse(Console.ReadLine());
            double underTwo = 0;
            double twoAndFour = 0;
            double fourAndSix = 0;
            double sixAndEight = 0;
            double overEight = 0;

            for (int i = 0; i < countNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    underTwo++;
                }
                else if (number >= 200 && number <= 399)
                {
                    twoAndFour++;
                }
                else if (number >= 400 && number <= 599)
                {
                    fourAndSix++;
                }
                else if (number >= 600 && number <= 799)
                {
                    sixAndEight++;
                }
                else if (number >= 800)
                {
                    overEight++;
                }
            }
            double underTwoPercent = underTwo / countNumbers * 100.0;
            double twoAndFourPercent = twoAndFour / countNumbers * 100.0;
            double fourAndSixPercent = fourAndSix / countNumbers * 100.0;
            double sixAndEightPercent = sixAndEight / countNumbers * 100.0;
            double overEightPecent = overEight / countNumbers * 100.0;
            Console.WriteLine($"{underTwoPercent:f2}%");
            Console.WriteLine($"{twoAndFourPercent:f2}%");
            Console.WriteLine($"{fourAndSixPercent:f2}%");
            Console.WriteLine($"{sixAndEightPercent:f2}%");
            Console.WriteLine($"{overEightPecent:f2}%");

        }
    }
}
