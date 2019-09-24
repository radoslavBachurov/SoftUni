using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] parenthesis = Console.ReadLine().ToCharArray();
            Stack<char> checking = new Stack<char>();

            checking.Push(parenthesis[0]);

            for (int i = 1; i < parenthesis.Length; i++)
            {
                switch (parenthesis[i])
                {
                    case ')':
                        if (checking.Any() && checking.Peek() == '(')
                        {
                            checking.Pop();
                        }
                        else
                        {
                            checking.Push(parenthesis[i]);
                        }
                        break;

                    case '}':
                        if (checking.Any() && checking.Peek() == '{')
                        {
                            checking.Pop();
                        }
                        else
                        {
                            checking.Push(parenthesis[i]);
                        }
                        break;
                    case ']':
                        if (checking.Any() && checking.Peek() == '[')
                        {
                            checking.Pop();
                        }
                        else
                        {
                            checking.Push(parenthesis[i]);
                        }
                        break;
                    default:
                        checking.Push(parenthesis[i]);
                        break;

                }

            }

            if (checking.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}