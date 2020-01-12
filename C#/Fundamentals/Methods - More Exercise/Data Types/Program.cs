using System;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();
            int number = 0;
            double real = 0;

            if (int.TryParse(input, out number) && type == "int")
                ExecutingOperation(number);
            else if (double.TryParse(input, out real)&&type=="real")
                ExecutingOperation(real);
            else
                ExecutingOperation(input);


        }

        private static void ExecutingOperation(string input)
        {
            Console.WriteLine($"${input}$");
        }

        private static void ExecutingOperation(double real)
        {
            Console.WriteLine($"{(real * 1.5):f2}");
        }

        private static void ExecutingOperation(int number)
        {
            Console.WriteLine(number * 2);
        }
    }
}
