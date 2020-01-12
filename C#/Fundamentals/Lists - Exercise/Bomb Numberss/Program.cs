using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numberss
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombDigit = bombPower[0];
            int powerDigit = bombPower[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombDigit)
                {
                    for (int t = 0; t < powerDigit; t++)
                    {
                        int index = 1;
                        if (i + index < numbers.Count)
                        {
                            numbers.RemoveAt(i + 1);
                            index++;
                        }
                    }
                    for (int t = 0; t < powerDigit; t++)
                    {
                        int index = 1;
                        if (i - index >= 0)
                        {
                            numbers.RemoveAt(i - 1);
                            i--;
                        }
                    }

                    numbers.RemoveAt(i);
                    i = -1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
