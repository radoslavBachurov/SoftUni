using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double incomeLv = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimumWage = double.Parse(Console.ReadLine());

            double socialScollership = Math.Floor(minimumWage * 0.35);
            double highGradeScShip = Math.Floor(averageGrade * 25);

            if (incomeLv <= minimumWage && averageGrade >= 5.5 )
            {
                if (socialScollership > highGradeScShip)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScollership} BGN");
                   
                }
                else if (highGradeScShip > socialScollership)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {highGradeScShip} BGN");
                }
                else if (socialScollership == highGradeScShip)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {highGradeScShip} BGN");
                }
            }
            else if (averageGrade >= 5.5 && incomeLv > minimumWage)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highGradeScShip} BGN");
            }

            else if (averageGrade > 4.5 && incomeLv < minimumWage)
            {
                Console.WriteLine($"You get a Social scholarship {socialScollership} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            

            
        }
    }
}
