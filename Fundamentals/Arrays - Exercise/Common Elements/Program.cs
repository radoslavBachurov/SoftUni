using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ").ToArray();
            string[] secondArray = Console.ReadLine().Split(" ").ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int t = 0; t < firstArray.Length; t++)
                {
                    if(firstArray[t]==secondArray[i])
                        Console.Write($"{firstArray[t]} ");
                }
            }
        }
    }
}
