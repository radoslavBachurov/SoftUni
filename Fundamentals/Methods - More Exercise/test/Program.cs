using System;
using System.Linq;
using System.Collections.Generic;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    arr = exchange(arr, int.Parse(command[1]));
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    findMinMax(arr, command[0], command[1]);
                }
                else
                {
                    findNumbers(arr, command[0], int.Parse(command[1]), command[2]);
                }

                // Console.WriteLine("[" + string.Join(", ", arr) + "]");
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        static int[] exchange(int[] arr, int indexSplit)
        {
            if (indexSplit >= arr.Length || indexSplit < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            int[] exchangedArr = new int[arr.Length];
            int index = 0;

            for (int i = indexSplit + 1; i < arr.Length; i++)
            {
                exchangedArr[index] = arr[i];
                index++;
            }

            for (int i = 0; i <= indexSplit; i++)
            {
                exchangedArr[index] = arr[i];
                index++;
            }

            return exchangedArr;
        }

        static void findMinMax(int[] arr, string minOrMax, string evenOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;

            int resultOddEven = 1;
            if (evenOdd == "even") resultOddEven = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == resultOddEven)
                {
                    if (minOrMax == "min" && min >= arr[i])
                    {
                        min = arr[i];
                        index = i;
                    }
                    else if (minOrMax == "max" && max <= arr[i])
                    {
                        index = i;
                        max = arr[i];
                    }
                }
            }
            if (index > -1) Console.WriteLine(index);
            else Console.WriteLine("No matches");
        }

        static void findNumbers(int[] arr, string position, int numbersCount, string evenOdd)
        {
            if (numbersCount > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (numbersCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int resultOddEven = 1;

            if (evenOdd == "even") resultOddEven = 0;

            int count = 0;
            List<int> nums = new List<int>();

            if (position == "first")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(arr[i]);
                    }

                    if (count == numbersCount) break;
                }
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(arr[i]);
                    }

                    if (count == numbersCount) break;
                }
                nums.Reverse();
            }

            Console.WriteLine("[{0}]", string.Join(", ", nums));
        }
    }
}