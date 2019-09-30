using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> listValues = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var item in input)
            {
                if(!listValues.ContainsKey(item))
                {
                    listValues.Add(item, 0);
                }
                listValues[item]++;
            }

            foreach (var item in listValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
            
        }
    }
}
