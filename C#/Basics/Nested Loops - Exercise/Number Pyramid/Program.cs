using System;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int printNumber = 1;

            for (int i = 1; i <= number; i++)
            {
                for (int r = 1; r <= i; r++)
                {
                    Console.Write($"{printNumber} ");
                    if (printNumber == number)
                    {
                        return;
                    }
                    printNumber++;
                   
                }
                Console.WriteLine();
            }
        }
    }
}

