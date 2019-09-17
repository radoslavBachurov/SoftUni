using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> newStack = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray().Reverse());

            while (newStack.Count > 1)
            {
                int firstNumber = int.Parse(newStack.Pop());
                string operand = newStack.Pop();
                int secondNumber = int.Parse(newStack.Pop());

                switch(operand)
                {
                    case "-":
                        newStack.Push((firstNumber - secondNumber).ToString());
                        break;
                    case "+":
                        newStack.Push((firstNumber + secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(newStack.Peek());
        }
    }
}
