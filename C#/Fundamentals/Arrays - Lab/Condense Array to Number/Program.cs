using System;
using System.Linq;

namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] newArr = new int[arr.Length - 1];
            while (arr.Length > 1)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    newArr[i] = arr[i] + arr[i + 1];
                }
                arr = newArr;
                newArr = new int[arr.Length - 1];
            }
            Console.WriteLine(arr[0]);


        }
    }
}
