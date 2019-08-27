using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberJourey = int.Parse(Console.ReadLine());
            string presentation = string.Empty;
            double averageGradeSum = 0;
            int counter = 0;

            while (true)
            {
                presentation = Console.ReadLine();
                if(presentation=="Finish")
                {
                    break;
                }
                double sumEvaluation = 0;

                for (int i = 0; i < numberJourey; i++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    sumEvaluation += evaluation;
                }
                double averageEvaluation = sumEvaluation / numberJourey;

                Console.WriteLine($"{presentation} - {averageEvaluation:f2}.");

                averageGradeSum += averageEvaluation;
                counter++;
            }
            double averageGradeTotal = averageGradeSum / counter;
            Console.WriteLine($"Student's final assessment is {averageGradeTotal:f2}.");

        }
    }
}
