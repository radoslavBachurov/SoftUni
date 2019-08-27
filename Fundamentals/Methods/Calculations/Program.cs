using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Operation(command, firstNumber, secondNumber);

        }

        private static void Operation(string command, int firstNumber, int secondNumber)
        {
            switch (command)
            {
                case "divide":
                    Console.WriteLine(firstNumber/secondNumber);
                    break;
                case "subtract":
                    Console.WriteLine(firstNumber-secondNumber);
                    break;
                case "multiply":
                    Console.WriteLine(firstNumber*secondNumber);
                    break;
                case "add":
                    Console.WriteLine(firstNumber+secondNumber);
                    break;
            }
        }
    }
}
