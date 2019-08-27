using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            double smallestNumber = GetSmallestNumber(firstNumber,secondNumber,thirdNumber);
            Console.WriteLine(smallestNumber);
        }

        private static double GetSmallestNumber(double firstNumber, double secondNumber, double thirdNumber)
        {
            return Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
        }
    }
}
