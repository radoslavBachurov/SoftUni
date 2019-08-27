using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            bool noCombinations = false;
            int counterTwo = 0;
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int s = firstNumber; s <= secondNumber; s++)
                {
                    counterTwo++;
                    if (s + i == magicNumber)
                    {
                        noCombinations = true;
                        Console.WriteLine($"Combination N:{counterTwo} ({i} + {s} = {magicNumber})");
                        return;
                    }

                }
            }
            if (noCombinations == false)
                Console.WriteLine($"{counterTwo} combinations - neither equals {magicNumber}");


        }
    }
}
