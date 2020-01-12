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
            double divideTwo = 0;
            double divideFour = 0;
            double divideThree = 0;
            

            for (int i = 0; i < countNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    divideTwo++;
                }
                 if (number % 3 == 0)
                {
                    divideThree++;
                }
                 if (number % 4 == 0)
                {
                    divideFour++;
                }
               
            }
            double divideTwoPercent = divideTwo / countNumbers * 100.0;
            double divideThreePercent = divideThree / countNumbers * 100.0;
            double divideFourPercent = divideFour / countNumbers * 100.0;
            
            Console.WriteLine($"{divideTwoPercent:f2}%");
            Console.WriteLine($"{divideThreePercent:f2}%");
            Console.WriteLine($"{divideFourPercent:f2}%");
            
        }
    }
}
