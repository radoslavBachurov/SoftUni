using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var newList = new List<double>();

            for (int i = 0; i < count; i++)
            {
                newList.Add(double.Parse(Console.ReadLine()));
            }

            var newBox = new Box<double>(newList);
            Console.WriteLine(newBox.Comparrison(double.Parse(Console.ReadLine())));
        }
    }
}
