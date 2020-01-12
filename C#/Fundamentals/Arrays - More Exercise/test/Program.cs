using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements___EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int longestSequenses = 0;
            int maxSequenses = 0;
            int numberValue = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int k = i; k < input.Length; k++)
                {
                    if (input[i] == input[k])
                    {

                        longestSequenses++;
                        if (longestSequenses > maxSequenses)
                        {
                            maxSequenses = longestSequenses;
                            numberValue = input[i];
                        }


                    }
                    else
                    {
                        longestSequenses = 0;
                        
                    }
                }
                longestSequenses = 0;
            }
            for (int i = 0; i < maxSequenses; i++)
            {
                Console.Write(numberValue + " ");
            }


        }
    }
}