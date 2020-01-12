using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToCharArray().ToList();
            List<char> cutted = new List<char>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] != '>')
                {
                    cutted.Add(input[i]);
                }
                else
                {
                    cutted.Add(input[i]);
                    int endIndex = i + int.Parse(input[i + 1].ToString());

                    for (int t = i + 1; t <= endIndex; t++)
                    {
                        if (input[t] == '>')
                        {
                            cutted.Add(input[t]);
                            endIndex = t + 1 + int.Parse(input[t + 1].ToString());
                        }

                        if (t == input.Count - 1)
                        {
                            break;
                        }

                    }

                    i = endIndex;

                    if (i == input.Count - 1)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("", cutted));
        }
    }
}
