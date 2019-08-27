using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double sumGrades = 0;
            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    counter++;
                    sumGrades += grade;
                }
                else if (grade < 4)
                {

                }

            }
            sumGrades = sumGrades / 12;
            Console.WriteLine($"{name} graduated. Average grade: {sumGrades:f2}");
            
        }
    }
}
