using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int sumOfElements = 0;

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int valueOfelement = numbers[0];
                    sumOfElements += valueOfelement;
                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                   
                    IncreasingDecreasingNumbers(numbers, index, valueOfelement);
                }
                else if (index >= numbers.Count)
                {
                    int valueOfelement = numbers[numbers.Count-1];
                    sumOfElements += valueOfelement;
                    numbers.RemoveAt(numbers.Count-1);
                    numbers.Add(numbers[0]);
                    
                    IncreasingDecreasingNumbers(numbers, index, valueOfelement);

                }
                else
                {
                    int valueOfelement = numbers[index];
                    sumOfElements += valueOfelement;
                    numbers.RemoveAt(index);
                    
                    IncreasingDecreasingNumbers(numbers, index,valueOfelement);
                }
            }
            Console.WriteLine(sumOfElements);
        }

        private static void IncreasingDecreasingNumbers(List<int> numbers, int index,int valueofElement)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= valueofElement )
                {
                    numbers[i] += valueofElement;
                }
                else if (numbers[i] > valueofElement)
                {
                    numbers[i] -= valueofElement;
                }

            }
        }

       
    }
}
