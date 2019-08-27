using System;

namespace Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstDigit = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondDigit = double.Parse(Console.ReadLine());

            double result = DefiningOperation(firstDigit, secondDigit, operation);
            Console.WriteLine(result);
        }

        private static double DefiningOperation(double firstDigit, double secondDigit, char operation)
        {
            double result = 0;

            switch(operation)
            {
                case '/':
                    result = firstDigit / secondDigit;
                    break;
                case '*':
                    result = firstDigit * secondDigit;
                    break;
                case '+':
                    result = firstDigit + secondDigit;
                    break;
                case '-':
                    result = firstDigit - secondDigit;
                    break;
            }

            return result;
        }
    }
}
