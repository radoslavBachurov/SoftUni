using System;

namespace Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal numberOne = decimal.Parse(Console.ReadLine());
            decimal numberTwo = decimal.Parse(Console.ReadLine());
            bool eps = true;

            decimal difference = Math.Abs(numberOne - numberTwo);

            if (difference >= 0.000001m)
                eps = false;

            Console.WriteLine(eps);

        }
    }
}
