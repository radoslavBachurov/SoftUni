using System;
using System.Linq;

namespace Threeuple
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

                if (input.Length >= 4)
                {
                    string name = input[0] + " " + input[1];
                    string living = input[2];
                    string town = input[3];
                    if (input.Length == 5)
                    {
                        town += " " + input[4];
                    }
                    var newTuple = new Threeuple<string, string, string>(name, living, town);
                    Console.WriteLine(newTuple.ToString());
                }
                else
                {
                    if (int.TryParse(input[1], out int tryParseResultInt))
                    {
                        bool drunk = false;
                        if (input[2] == "drunk")
                            drunk = true;

                        var newTuple = new Threeuple<string, int, bool>(input[0], tryParseResultInt, drunk);
                        Console.WriteLine(newTuple.ToString());
                    }
                    else
                    {
                        string name = input[0];
                        double secondInput = double.Parse(input[1]);
                        var newTuple = new Threeuple<string, double, string>(name, secondInput, input[2]);
                        Console.WriteLine(newTuple.ToString());
                    }
                }
            }
        }
    }
}
