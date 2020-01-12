using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString = Console.ReadLine();

            int lenth = numberString.Length;
            int number = int.Parse(numberString);
            for (int collums = 0; collums < lenth; collums++)
            {
                int lastNumber = number % 10;
                number /= 10;
                if(lastNumber == 0)
                {
                    Console.WriteLine("ZERO");
                }
                for (int countSymbols = 1; countSymbols <= lastNumber; countSymbols++)
                {
                    Console.Write($"{(char)(lastNumber+33)}");
                    if(countSymbols == lastNumber)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
