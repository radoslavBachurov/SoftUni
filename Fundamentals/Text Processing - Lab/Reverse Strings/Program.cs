using System;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                char[] inputArr = input.ToCharArray().Reverse().ToArray();
                string reversed = string.Join("", inputArr);

                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}