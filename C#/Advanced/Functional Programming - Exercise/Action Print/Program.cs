using System;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printing = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            printing(input);
        }
    }
}
