using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Func<int, int[], List<int>> listOfNumbers = (range, divideNumebrs) =>
              {
                  List<int> numbers = new List<int>();
                  for (int i = 1; i <= range; i++)
                  {
                      bool dividedConfirmed = true;

                      for (int t = 0; t < divideNumebrs.Length; t++)
                      {
                          if (i % divideNumebrs[t] != 0)
                          {
                              dividedConfirmed = false;
                          }
                      }

                      if(dividedConfirmed)
                      {
                          numbers.Add(i);
                      }
                  }
                  return numbers;
              };

            List<int> sortedList = listOfNumbers(endRange, dividers);
            Console.WriteLine(string.Join(" ",sortedList));
        }
    }
}
