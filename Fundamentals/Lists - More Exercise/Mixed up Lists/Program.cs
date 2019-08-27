using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            List<int> secondNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();

            MixingUpLists(firstNumbers, secondNumbers, mixedList);

            List<int> range = SettingUpRange(firstNumbers, secondNumbers);

            PrintingNumbers(range, mixedList);

        }

        private static void PrintingNumbers(List<int> range, List<int> mixedList)
        {
            int startRange = Math.Min(range[0], range[1]);
            int endRange = Math.Max(range[0], range[1]);
            List<int> numbersForPrint = new List<int>();

            foreach (var item in mixedList)
            {
                if (item > startRange && item < endRange)
                {
                    numbersForPrint.Add(item);
                }
            }

            numbersForPrint.Sort();
            Console.WriteLine(string.Join(" ", numbersForPrint));
        }

        private static List<int> SettingUpRange(List<int> firstNumbers, List<int> secondNumbers)
        {
            if (secondNumbers.Count > firstNumbers.Count)
            {
                return secondNumbers;
            }
            else
            {
                return firstNumbers;
            }
        }

        private static void MixingUpLists(List<int> firstNumbers, List<int> secondNumbers, List<int> mixedList)
        {
            int smallerCount = Math.Min(firstNumbers.Count, secondNumbers.Count);
            int biggerCount = (Math.Max(firstNumbers.Count, secondNumbers.Count)) - 1;

            for (int i = 0; i < smallerCount; i++, biggerCount--)
            {
                mixedList.Add(firstNumbers[0]);
                mixedList.Add(secondNumbers[secondNumbers.Count - 1]);
                firstNumbers.RemoveAt(0);
                secondNumbers.RemoveAt(secondNumbers.Count - 1);
            }

        }
    }
}
