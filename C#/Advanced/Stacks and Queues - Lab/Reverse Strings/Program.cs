using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> newStack = new Stack<char>(Console.ReadLine().ToCharArray());
            int count = newStack.Count;

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"{newStack.Pop()}");
            }
        }
    }
}
