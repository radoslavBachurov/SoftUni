using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack mystack = new CustomStack();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Pop")
                {
                    try
                    {
                        mystack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No elements");
                    }
                }
                else
                {
                    int[] commandArr = command.Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1).Select(int.Parse).ToArray();
                    mystack.Push(commandArr);
                }
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
