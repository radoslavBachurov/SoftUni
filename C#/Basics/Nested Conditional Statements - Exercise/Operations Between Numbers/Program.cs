using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            


            if (operation == '+')
            {
                double plus = number1 + number2;
                double oddOrEven = plus % 2;
                if (oddOrEven == 0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - even");
                }
                else if(oddOrEven !=0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - odd");
                }
            }
            else if (operation == '-')
            {
                double plus = number1 - number2;
                double oddOrEven = plus % 2;
                if (oddOrEven == 0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - even");
                }
                else if (oddOrEven != 0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - odd");
                }

            }
            else if (operation == '*')
            {
                double plus = number1 * number2;
                double oddOrEven = plus % 2;
                if (oddOrEven == 0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - even");
                }
                else if (oddOrEven != 0)
                {
                    Console.WriteLine($"{number1} {operation} {number2} = {plus} - odd");
                }

            }
            else if (operation == '%' && number2 != 0)
            {
                double oddOrEven = number1%number2;
                Console.WriteLine($"{number1} % {number2} = {oddOrEven}");
            }
            else if (operation == '/' && number2 != 0)
            {
                double oddOrEven = number1 / number2;
                Console.WriteLine($"{number1} / {number2} = {oddOrEven:f2}");

            }
            else if(number2 == 0)
            {
                Console.WriteLine($"Cannot divide {number1} by zero");
            }

        }
    }
}
