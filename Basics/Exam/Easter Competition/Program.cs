using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberKozunaks = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            string winner = string.Empty;
            int lastSum = 0;

            for (int i = 0; i < numberKozunaks; i++)
            {
                string chefName = Console.ReadLine();
                int sumEvaluation = 0;

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Stop")
                    {
                        break;
                    }

                    int evaluation = int.Parse(command);
                    sumEvaluation += evaluation;
                    
                    if (sumEvaluation > max)
                    {
                        max = sumEvaluation;
                        winner = chefName;
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine($"{chefName} has {sumEvaluation} points.");
                    Console.WriteLine($"{chefName} is the new number 1!");
                }
                else if (sumEvaluation > lastSum)
                {
                    Console.WriteLine($"{chefName} has {sumEvaluation} points.");
                    Console.WriteLine($"{chefName} is the new number 1!");
                }
                else
                {
                    Console.WriteLine($"{chefName} has {sumEvaluation} points.");
                }
                lastSum = sumEvaluation;
            }
            Console.WriteLine($"{winner} won competition with {max} points!");



        }
    }
}
