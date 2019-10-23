using System;
using System.Linq;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine()
                                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                  .ToArray();

                if (input.Length > 2)
                {
                    string name = input[0] + " " + input[1];
                    string living = input[2];
                    var newTuple = new Tuple<string, string>(name, living);
                    Console.WriteLine(newTuple.ToString());
                }
                else
                {
                    if (int.TryParse(input[0], out int tryParseResultInt))
                    {
                        double secondInput = double.Parse(input[1]);
                        var newTuple = new Tuple<int, double>(tryParseResultInt, secondInput);
                        Console.WriteLine(newTuple.ToString());
                    }
                    else
                    {
                        string name = input[0];
                        int secondInput = int.Parse(input[1]);
                        var newTuple = new Tuple<string, int>(name, secondInput);
                        Console.WriteLine(newTuple.ToString());
                    }
                }
            }
        }
    }
}
