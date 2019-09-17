using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> indexes = new Stack<int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i]=='(')
                {
                    indexes.Push(i);
                }
                else if(input[i]==')')
                {
                    int closeIndex = i;
                    int openIndex = indexes.Pop();
                    int countSymbols = closeIndex - openIndex;

                    string part = input.Substring(openIndex, countSymbols+1);
                    Console.WriteLine(part);
                }
            }


        }
    }
}
