using System;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumer = int.Parse(Console.ReadLine());

            int sum = SumFirstTwoNumbers(firstNumber,secondNumber);
            int substract = SubstractThirdNumberFromSum(sum, thirdNumer);
            Console.WriteLine(substract);
        }

        private static int SubstractThirdNumberFromSum(int sum, int thirdNumer)
        {
            return sum - thirdNumer;
        }

        private static int SumFirstTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
