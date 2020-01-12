using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_Loops_More_Exercises___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            for (int i = 2; i <= firstNumber; i++)
            {
                for (int d = 2; d <= secondNumber && d <= 7; d++)
                {
                    for (int s = 2; s <= thirdNumber; s++)
                    {
                        if (i % 2 == 0 && s % 2 == 0 && (d == 2 || d == 3 || d == 5 || d == 7))
                            Console.WriteLine($"{i} {d} {s}");
                    }
                }
            }
        }
    }
}
