using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var newList = new List<string>();
            
            for (int i = 0; i < count; i++)
            {
                newList.Add(Console.ReadLine());
            }

            Box<string> newBox = new Box<string>(newList);
            Console.WriteLine(newBox.Comparrison(Console.ReadLine()));
        }
    }
}
