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
            int secondChance = 0;

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
                    
                    secondChance++;
                    if (secondChance == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {counter} grade");
                        break;
                    }
                }

            }
            if (counter == 13)
            {
                sumGrades = sumGrades / 12;
                Console.WriteLine($"{name} graduated. Average grade: {sumGrades:f2}");
            }

        }
    }
}


