using System;

namespace Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= number; i++)
            {
                counter++;
                Console.WriteLine();

                for (int h = 0; h < counter; h++)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
