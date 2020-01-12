using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 2;
            string[] firstLine = new string[lines];
            string[] secondLine = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                if (counter % 2 == 0)
                {
                    firstLine[i] = input[0];
                    secondLine[i] = input[1];
                }

                else
                {
                    firstLine[i] = input[1];
                    secondLine[i] = input[0];
                }
                counter++;
            }
            Console.WriteLine(string.Join(" ",firstLine));
            Console.WriteLine(string.Join(" ",secondLine));
        }
    }
}
