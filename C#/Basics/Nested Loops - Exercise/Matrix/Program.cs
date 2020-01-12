using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());
            

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int f = firstNumber; f <= secondNumber; f++)
                {
                    for (int t = thirdNumber; t <= fourthNumber; t++)
                    {
                        for (int k = thirdNumber; k <= fourthNumber; k++)
                        {
                            bool matrixCondition = i + k == f + t;
                            bool matrixRepeat = i != f && t != k;
                            if (matrixRepeat && matrixCondition)
                            {
                                Console.WriteLine($"{i}{f}");
                                Console.WriteLine($"{t}{k}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

        }
    }
}
