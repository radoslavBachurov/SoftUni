using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int> executing = x => x;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        executing = x => ++x;
                        break;
                    case "multiply":
                        executing = x => x*=2;
                        break;

                    case "subtract":
                        executing = x => --x;
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        continue;

                }

                numbers = numbers.Select(executing).ToArray();
            }

        }
    }
}
