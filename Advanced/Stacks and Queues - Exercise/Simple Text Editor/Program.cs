using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int numberOperations = int.Parse(Console.ReadLine());
            Stack<string> typeOperations = new Stack<string>();

            for (int i = 0; i < numberOperations; i++)
            {
                string[] commandArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArr[0] == "1")
                {
                    typeOperations.Push(text);
                    text += commandArr[1];
                }
                else if (commandArr[0] == "2")
                {
                    typeOperations.Push(text);
                    int countElements = int.Parse(commandArr[1]);
                    text = text.Remove(text.Length - countElements, countElements);
                }
                else if (commandArr[0] == "3")
                {
                    int index = int.Parse(commandArr[1]);

                    if (text.Length > index-1)
                    {
                        Console.WriteLine(text[index-1].ToString());
                    }

                }
                else if (commandArr[0] == "4")
                {
                    text = typeOperations.Pop();
                }
            }
        }
    }
}
