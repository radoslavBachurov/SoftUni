using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
           var listNumbers = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if(listNumbers.ContainsKey(numbers[i]))
                {
                    listNumbers[numbers[i]]++;
                }
                else
                {
                    listNumbers.Add(numbers[i], 1);
                }
            }

            foreach (var item in listNumbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
