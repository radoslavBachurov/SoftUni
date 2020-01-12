using System;

namespace Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool prime = true;
                for (int t = 2; t < i; t++)
                {
                    if (i % t == 0 && i != 2)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                    Console.WriteLine("{0} -> true", i);
                else
                    Console.WriteLine("{0} -> false", i);

            }

        }
    }
}
