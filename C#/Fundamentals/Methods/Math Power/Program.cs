using System;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double numberRaised = MathPower(number,power);
            Console.WriteLine(numberRaised);
        }

        private static double MathPower(double number , double power)
        {
            double numberRaised = number;
            for (int i = 1; i < power; i++)
            {
                numberRaised *= number;
            }
            return numberRaised;
        }
    }
}
