using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowEvaluationNumber = int.Parse(Console.ReadLine());
            int lowEvaluationCounter = 0;
            int numberProblems = 0;
            double sumScore = 0;
            string lastProblemName = "Test";
           

            while (lowEvaluationCounter < lowEvaluationNumber)
            {
                
                string problemName = Console.ReadLine();
                
                if (problemName == "Enough")
                {
                    Console.WriteLine($"Average score: {(sumScore / numberProblems):f2}");
                    Console.WriteLine($"Number of problems: {numberProblems}");
                    Console.WriteLine($"Last problem: {lastProblemName}");
                    break;
                }
                double evaluation = int.Parse(Console.ReadLine());
                numberProblems++;
                sumScore += evaluation;
                lastProblemName = problemName;
                if (evaluation <= 4 )
                {
                    lowEvaluationCounter++;
                    if (lowEvaluationNumber == lowEvaluationCounter)
                    {
                        Console.WriteLine($"You need a break, {lowEvaluationCounter} poor grades.");
                        break;
                    }

                }
                
                
            }
        }
    }
}
